using ProvaemCasaSimplificado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class JogarCommand:ICommand
    {
        private List<Carta> _cartas;
        public JogarCommand( List<Carta> command)
        {
            _cartas = command;
        }
        public List<Carta> Executar()
        {
           Console.WriteLine("Enviando a carta para a Banca");

            return null;
        }
    }
}
