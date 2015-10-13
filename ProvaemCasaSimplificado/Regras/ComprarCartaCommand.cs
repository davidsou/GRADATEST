using ProvaemCasaSimplificado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public class ComprarCartaCommand:ICommand
    {
        private Baralho _baralho;
        public ComprarCartaCommand(Baralho baralho)
        {    
            this._baralho = baralho;
        }
        public List<Carta> Executar()
        {
            List<Carta> aux = new List<Carta>();
            aux.Add(this._baralho.ObterPrimeiraCarta());
            return aux;
            
        }
    }
}
