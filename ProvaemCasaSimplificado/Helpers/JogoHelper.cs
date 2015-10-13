using ProvaemCasaSimplificado.Entidades;
using ProvaemCasaSimplificado.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Helpers
{
    public static class JogoHelper
    {
        public static void Show(List<Carta> cartas)
        {
            cartas.ForEach(x => Console.WriteLine("{0} - {1}:{2}", cartas.IndexOf(x), x.Naipe, x.Face));
        }
        public static void Show(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Show(Carta msg)
        {
            Console.WriteLine(msg.ToString());
        }
          public static void ShowEmLinha(string msg)
        {
            Console.Write(msg);
        }
        public static int GerarIndiceRandomico(List<Carta> cartas)
        {
            Random r = new Random();
            int indiceAleatorio = r.Next(cartas.Count);
            return indiceAleatorio;
        }

     


    }
}
