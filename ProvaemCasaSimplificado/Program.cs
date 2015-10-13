using ProvaemCasaSimplificado.Entidades;
using ProvaemCasaSimplificado.Helpers;
using ProvaemCasaSimplificado.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Banca banca = new Banca();
            JogoHelper.Show(Instrucoes.Inicio);
            string comando = Console.ReadLine().ToUpper().Trim();

            banca.Flxuo(comando);

        }
    }
}

