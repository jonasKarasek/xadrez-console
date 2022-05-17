﻿using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                        Console.Write("- ");//se não haver peça imprime espaço vazio
                    else
                    { 
                        imprimirPeca(tab.peca(i, j));//imprime peça
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branco)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
