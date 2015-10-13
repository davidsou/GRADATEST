using ProvaemCasaSimplificado.Entidades;
using System;
using System.Collections.Generic;
namespace ProvaemCasaSimplificado.Regras
{
    interface IJogador
    {
        Carta EnviaCarta();
        Carta EnviaCarta(int index);
        void EnviaComand();
        List<Carta> MinhasCartas { get; set; }
        int Pontuacao { get; set; }
        void setCommand(ICommand command);
        void Show();
    }
}
