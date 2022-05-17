using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i, j) == null)
                        Console.Write("- ");//se não haver peça imprime espaço vazio
                else
                    Console.Write(tab.peca(i, j) + " ");//imprime peça
                }
                Console.WriteLine();
            }
        }
    }
}
