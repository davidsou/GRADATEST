using ProvaemCasaSimplificado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Regras
{
    public interface ICommand
    {
         List<Carta> Executar();
    }
}
