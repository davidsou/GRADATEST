using ProvaemCasaSimplificado.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Entidades
{
    public class Baralho
    {
        public List<Carta> Cartas { get; private set; }
        public Baralho()
        {
            Cartas = new List<Carta>();
            this.CriaBaralho();
        }

        private void CriaBaralho()
        {
            //Console.WriteLine("Novo Baralho");
            foreach (NaipeEnum naipe in Enum.GetValues(typeof(NaipeEnum)))
            {
               // Console.WriteLine("Naipe de {0} ", naipe.ToString());

                foreach (ValorDaCartaEnum valorDaCarta in Enum.GetValues(typeof(ValorDaCartaEnum)))
                {
                    Carta novaCarta = new Carta() { Naipe = naipe, Face = valorDaCarta };
                    Cartas.Add(novaCarta);
                    string aux = valorDaCarta != ValorDaCartaEnum.REIS ? "," : ".";
               
                }
            }
        }

        public void EmbaralharCartas()
        {
            Console.WriteLine("Embaralhando Cartas...");
            Thread.Sleep(1000); 
            Random rand = new Random();

            this.Cartas = this.Cartas.OrderBy(c => rand.Next()).ThenByDescending(c => rand.Next()).Select(c => new Carta { Naipe = c.Naipe, Face = c.Face }).ToList();

        }
        public List<Carta> ObterCartas(int quantidade)
        {
            List<Carta> retorno = this.Cartas.Take(quantidade).ToList();
            this.Cartas = this.Cartas.Except(retorno).ToList();
            return retorno;
        }
        public void RetornarCartas(List<Carta> cartas)
        {
            this.Cartas.AddRange(cartas);

        }
        public Carta ObterPrimeiraCarta()
        {
            Carta retorno = this.Cartas.FirstOrDefault();
            if (this.Cartas.Count > 0)
            {
                this.Cartas.Remove(retorno);
                JogoHelper.Show(retorno.ToString());
            }
            
            return retorno;
        }

    }
}
