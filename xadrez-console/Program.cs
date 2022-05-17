using System;
using tabuleiro;
using xadrez;

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

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);//gera tabuleiro

                //posiciona peças
                tab.colocarPeca(new Rei(tab, Cor.Preto), new Posicao(0, 4));
                tab.colocarPeca(new Rei(tab, Cor.Branco), new Posicao(7, 3));

                Tela.imprimirTabuleiro(tab);//exibe tabuleiro
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            /*PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos.toPosicao());*/
        }
    }
}
