using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Entidades
{
    public class Carta
    {
        public NaipeEnum Naipe { get; set; }
        public ValorDaCartaEnum Face { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as Carta;
            bool response = false;
            if (this.Naipe == o.Naipe && this.Face == o.Face)
                response = true;
            return response;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
       
        public override string ToString()
        {
            string aux = String.Format("{0}:{1}", Naipe, Face); 
            return aux;
        }
    }
}
