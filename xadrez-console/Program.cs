using System;
using tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Posicao P;
            P = new Posicao(3, 4);//construtor da classe posição: definindo uma posição - linha 3 e coluna 4
            Console.WriteLine("Posição: " + P);//Apenas para exibir posição do objeto P
            */

            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.imprimirTabuleiro(tab);
        }
    }
}
