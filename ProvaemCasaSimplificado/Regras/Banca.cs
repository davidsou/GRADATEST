using ProvaemCasaSimplificado.Entidades;
using ProvaemCasaSimplificado.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class Banca
    {

        public Carta CartaLancada { get; set; }
        public Jogador Jogador { get; set; }
        public Maquina Maquina { get; set; }
        public Baralho Baralho { get; set; }

        private ICommand comando;
        private bool jogadesafiante;
        private int cartascompradasmaquina;

        private EstadoJogadasEnum estado;
        private delegate void ChamaDesafio();

        public Banca() { }
        /// <summary>
        /// Esta função Embaralha as cartas distribui as cartas inicialmente.
        /// </summary>
        /// 

        public void  Flxuo( string opcao)
        {
            opcao = opcao.ToUpper().Trim();
            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "I":
                        Console.Clear();
                        JogoHelper.Show(Instrucoes.Inicio);
                        break;
                    case "D":
                        Console.Clear();
                        JogoHelper.Show(Instrucoes.Comandos);
                        break;
                    case "S":
                        Console.Clear();
                        this.Jogador.Show();
                        break;
                    case "C":
                        this.ComprarCarta();
                        break;
                    case "R":
                        this.ShowBanca();
                        break;
                    case "J":
                        this.VerificaJogada();
                        break;
                    case "N":
                        this.IniciaJogo();
                        break;
                    case "Y":
                        this.Maquina.Show();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        JogoHelper.Show(Instrucoes.OperacaoInvalida);
                        break;
                }
                opcao = Console.ReadLine().ToUpper().Trim();
            }
            Environment.Exit(0);

        }
        public void IniciaJogo()
        {
            Baralho = new Baralho();

            // embaralha as cartas
            Baralho.EmbaralharCartas();
            Console.WriteLine("Distribuindo Cartas ao Jogador");

            //Configura o Comando ao Baralho para distribuir cartas para o Jogador A
            this.comando = new DarCartasCommand(Baralho);
            this.Jogador = new Jogador();
            Jogador.setCommand(comando);
            Jogador.EnviaComand();
            Jogador.Show();

            //Configura as Cartas do Console, que será o desafiante
            Maquina = new Maquina();
            Maquina.setCommand(comando);
            Maquina.EnviaComand();
            this.CartaLancada = Maquina.EnviaCarta();
            //Remove carta inicial da máquina
            Maquina.MinhasCartas.Remove(this.CartaLancada);
            // Console envia primeira carta;
            JogoHelper.Show(this.CartaLancada);
        }

        /// <summary>
        /// Solicita a primeira carta para o baralho utilizando padrão command.
        /// </summary>
        public void ComprarCarta()
        {
            this.comando = new ComprarCartaCommand(this.Baralho);
            this.Jogador.setCommand(comando);
            this.Jogador.EnviaComand();
        }

        /// <summary>
        /// Solicita a primeira carta para o baralho utilizando padrão command. tem o jogador da vez como parametro
        /// </summary>
        private void ComprarCarta(IJogador j)
        {
            this.comando = new ComprarCartaCommand(this.Baralho);
            j.setCommand(comando);
            j.EnviaComand();
        }
        /// <summary>
        /// Função para solicitar o embaralhamento das cartas. toda vez que for solicitado
        /// Para demostração, mostrará as cartas antes e depois de serem embaralhadas.
        /// </summary>
        public void Embaralhar()
        {
            this.Baralho.EmbaralharCartas();
        }

        public void InicioDesafio()
        {
            JogoHelper.Show(Instrucoes.Desafio);
            string aux = Console.ReadLine();

        }
        /// <summary>
        ///  Executa a validação da Jogada
        /// </summary>
        /// <param name="cartaescolhida"></param>

        public void VerificaJogada()
        {
            Desafio();

        }
        // Responde ao desafio da máquina
        private void Desafio()
        {
            this.estado = EstadoJogadasEnum.JogadorTentacobrirDesafio;
            this.ShowBanca();
            JogoHelper.ShowEmLinha(Instrucoes.Jogar);
            string aux = Console.ReadLine();
            VerificaCartaEscolhida(aux);
        }
        // Solicita ao Jogador que Lance a primeira carta do desafio
        private void Desafiar()
        {           
            bool acabou;
            string msg = VerificaFinalizacao(out acabou);
            if (!acabou)
            {
                this.estado = EstadoJogadasEnum.JogadorDesafia;
                JogoHelper.Show(Instrucoes.NovaJogada);
                this.Jogador.Show();
                JogoHelper.ShowEmLinha(Instrucoes.Jogar);
                string aux = Console.ReadLine();
                VerificaCartaEscolhida(aux);
            }
            else
            {
                JogoHelper.Show(msg);
            }
        }
        private void Valida(IJogador j, Carta c)
        {
            JogoHelper.Show(String.Format(Instrucoes.JogadaMaquina ,c.ToString()));
            if (this.CartaLancada.Naipe == c.Naipe)
            {
                j.MinhasCartas.Remove(c);
                this.CartaLancada = null;
                ChamaDesafio d = estado == EstadoJogadasEnum.JogadorTentacobrirDesafio ? new ChamaDesafio(this.Desafiar) : new ChamaDesafio(this.MaquinaDesafia);
                d();
            }
            else
            {
                ChamaDesafio d = estado == EstadoJogadasEnum.JogadorTentacobrirDesafio ? new ChamaDesafio(this.Desafio) : new ChamaDesafio(this.JogaMaquina);
                d();
            }

        }

        // Função compartilhada para verificar input do jogador.
        private void VerificaCartaEscolhida(string aux)
        {
            int cartaescolhida;
            if (int.TryParse(aux, out cartaescolhida))
            {
                Carta c = this.Jogador.MinhasCartas[cartaescolhida];
                this.CartaLancada = c;
                Jogar(c);
            }
            else
            {
                this.Flxuo(aux);
            }
        }
        public void Jogar(Carta lancada)
        {
            if (this.Baralho.Cartas.Count() == 0)
                Desafiar();

            switch (estado)
            {
                case EstadoJogadasEnum.JogadorTentacobrirDesafio:
                    Valida(this.Jogador, lancada);
                    break;

                case EstadoJogadasEnum.JogadorDesafia:
                    JogaMaquina();
                    break;

                case EstadoJogadasEnum.MaquinaTentaCobrirDesafio:
                    Valida(this.Maquina, lancada);
                    break;

                case EstadoJogadasEnum.MaquinaDesafia:
                    Desafio();
                    break;
                default:
                    break;
            }
        }


        private void MaquinaDesafia()
        {
            bool acabou;
            string msg = VerificaFinalizacao(out acabou);
            if (!acabou)
            {                
                this.Jogador.Show();
                this.CartaLancada = this.Maquina.EnviaCarta();
                Desafio();
            }
            else
            {
                JogoHelper.Show(msg);
            }
        }

        private void JogaMaquina()
        {
            List<Carta> c = this.Maquina.MinhasCartas.FindAll(x => x.Naipe == this.CartaLancada.Naipe).ToList();
            if (c != null && c.Count > 0)
            {
                Carta auxCarta = c.FirstOrDefault();
                estado = EstadoJogadasEnum.MaquinaTentaCobrirDesafio;
                Jogar(auxCarta);
            }
            else
            {
                ComprarCarta(this.Maquina);
                this.cartascompradasmaquina = +1;
                JogaMaquina();
            }

        }

        /// <summary>
        /// Função interna para verificar fim do Jogo
        /// </summary>
        /// <returns>Mensagem com instrução para continuar o jogo ou Vitória/Derrota</returns>
        private string VerificaFinalizacao(out bool acabou)
        {
            string resultado;
            int totalmaquina = this.Maquina.MinhasCartas.Count();
            int totaljogador = this.Jogador.MinhasCartas.Count();
            acabou = false;
            if (totaljogador == 0 || totalmaquina == 0)
            {
                resultado = totaljogador == 0 ? Instrucoes.Vencedor : Instrucoes.Perdedor;
                acabou = true;
            }
            else
            {
                resultado = Instrucoes.Aguardando;
                acabou = false;
            }
            return resultado;

        }
        public void ShowBanca()
        {
            string msg;
            if (this.CartaLancada == null)
            {
                msg = Instrucoes.CartaNaoLancada;
            }
            else
            {
                msg = this.CartaLancada.ToString();
            }
            JogoHelper.Show(msg);
        }


    }


}

