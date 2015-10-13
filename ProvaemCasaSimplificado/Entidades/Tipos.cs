using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaemCasaSimplificado.Entidades
{
    public enum NaipeEnum
    {
        COPAS = 0,
        OUROS = 1,
        ESPADAS = 2,
        PAUS = 3
    }
    public enum ValorDaCartaEnum
    {
        AS = 1,
        DOIS = 2,
        TRES = 3,
        QUATRO = 4,
        CINCO = 5,
        SEIS = 6,
        SETE = 7,
        OITO = 8,
        NOVE = 9,
        DEZ = 10,
        VALETE = 11,
        DAMA = 12,
        REIS = 13
    }

    public enum EstadoJogadasEnum
    {
        JogadorTentacobrirDesafio = 1,
        JogadorDesafia = 2,
        MaquinaTentaCobrirDesafio = 3,
        MaquinaDesafia = 4
    }
}
