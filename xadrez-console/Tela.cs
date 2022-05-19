using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            ConsoleColor fundoEscuro = ConsoleColor.DarkGray;
            ConsoleColor fundoClaro = ConsoleColor.Gray;
            
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(8 - i + "  ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                        Console.BackgroundColor = fundoClaro;
                    else
                        Console.BackgroundColor = fundoEscuro;

                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n   A B C D E F G H");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoes)//imprime marcando possibilidades de movimentação para uma peça
        {
            ConsoleColor fundoEscuro = ConsoleColor.DarkGray;
            ConsoleColor fundoClaro = ConsoleColor.Gray;
            ConsoleColor fundoEspecialClaro = ConsoleColor.Blue;
            ConsoleColor fundoEspecialEscuro = ConsoleColor.DarkBlue;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black; 
                Console.Write(8 - i + "  ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoes[i, j])
                    {
                        if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                            Console.BackgroundColor = fundoEspecialClaro;
                        else
                            Console.BackgroundColor = fundoEspecialEscuro;
                    }
                    else
                    {
                        if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                            Console.BackgroundColor = fundoClaro;
                        else
                            Console.BackgroundColor = fundoEscuro;
                    }                  
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n   A B C D E F G H");
        }
        public static PosicaoXadrez lerPosicaoXadrez()//dados de entrada -> padrão xadrez de posições
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            Console.Write("  ");//se não haver peça imprime espaço vazio
            else
            {
                if (peca.cor == Cor.Branco)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
