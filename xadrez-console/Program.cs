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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);//exibe tabuleiro

                    Console.WriteLine("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);//exibe tabuleiro com possiveis movimentações
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                } 
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
