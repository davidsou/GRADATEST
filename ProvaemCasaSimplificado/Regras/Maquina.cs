using ProvaemCasaSimplificado.Entidades;
using ProvaemCasaSimplificado.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class Maquina : IJogador
    {
        private ICommand _command;
        public List<Carta> MinhasCartas { get; set; }
        public int Pontuacao { get; set; }

        public Maquina()
        {
            this.MinhasCartas = new List<Carta>();
        }
        public void setCommand(ICommand command)
        {
            this._command = command;
        }

        public void EnviaComand()
        {
            this.MinhasCartas.AddRange( _command.Executar());
        }

        public void Show()
        {
            if (this.MinhasCartas != null && this.MinhasCartas.Count() > 0)
                JogoHelper.Show(this.MinhasCartas);
        }

        public Carta EnviaCarta()
        {
            return this.MinhasCartas[JogoHelper.GerarIndiceRandomico(this.MinhasCartas)];
        }

        public Entidades.Carta EnviaCarta(int index)
        {
            return this.MinhasCartas[index];
        }

    }
}
