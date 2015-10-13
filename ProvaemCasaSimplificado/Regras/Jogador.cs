using ProvaemCasaSimplificado.Entidades;
using ProvaemCasaSimplificado.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class Jogador : IJogador
    {
        private ICommand _command;
        private int _console;

        public int Pontuacao { get; set; }

        public List<Carta> MinhasCartas { get; set; }

        public Jogador() 
        {
            this.MinhasCartas = new List<Carta>();
        }


        public void setCommand(ICommand command)
        {
            this._command = command;
        }

        public void EnviaComand()
        {
            
            this.MinhasCartas.AddRange(_command.Executar());
        }

        public void Show()
        {
            if (this.MinhasCartas != null && this.MinhasCartas.Count() >0)
                JogoHelper.Show(this.MinhasCartas);
        }

        public Carta EnviaCarta()
        {

            return MinhasCartas.FirstOrDefault();

        }
        public Carta EnviaCarta(int index)
        {
            return MinhasCartas[index];
        }




    }
}
