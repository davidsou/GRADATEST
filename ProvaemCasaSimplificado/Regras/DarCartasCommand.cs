using ProvaemCasaSimplificado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class DarCartasCommand : ICommand
    {
        private Baralho _baralho;
        public DarCartasCommand(Baralho baralho)
        {
            this._baralho = baralho;
        }


        List<Carta> Executar()
        {
            Console.WriteLine("Distribuindo as cartas do Jogador");
            return this._baralho.ObterCartas(7);
        }

        List<Carta> ICommand.Executar()
        {
            Console.WriteLine("Distribuindo as cartas do Jogador");
            return this._baralho.ObterCartas(7);
        }
    }
}
