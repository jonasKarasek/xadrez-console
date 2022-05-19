using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);//exibe tabuleiro
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogador " + partida.jogadorAtual);
        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas");

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("Brancas: ");

            imprimirConjunto(partida.pecasCapturadas(Cor.Branco));

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Pretas: ");

            imprimirConjunto(partida.pecasCapturadas(Cor.Preto));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
                Console.Write(x + " ");

            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)//exibição simples
        {            
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(8 - i + "  ");//imprime coluna de números para posição do tabuleiro

                for (int j = 0; j < tab.colunas; j++)
                {
                    //colore tabuleiro
                    if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                        Console.BackgroundColor = ConsoleColor.Gray;//fundo claro
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;//fundo escuro

                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n   A B C D E F G H");//imprime letras para posição do tabuleiro
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoes)//imprime marcando possibilidades de movimentação para uma peça
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black; 
                Console.Write(8 - i + "  ");//imprime coluna de números para posição do tabuleiro

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoes[i, j])
                    {
                        if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                            Console.BackgroundColor = ConsoleColor.Blue;//fundo claro para posições possíveis de jogar
                        else
                            Console.BackgroundColor = ConsoleColor.DarkBlue;//fundo escuro para posições possíveis de jogar
                    }
                    else
                    {
                        if (i % 2 == 1 && j % 2 == 0 || i % 2 == 0 && j % 2 == 1)
                            Console.BackgroundColor = ConsoleColor.Gray;//fundo claro
                        else
                            Console.BackgroundColor = ConsoleColor.DarkGray;//fundo escuro
                    }                  
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n   A B C D E F G H");//imprime letras para posição do tabuleiro
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
            Console.Write("  ");//imprime espaço vazio se não houver peça 
            else
            {
                if (peca.cor == Cor.Branco)
                {
                    //ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;//peça branca
                    Console.Write(peca);
                    //Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    //ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;//peça preta
                    Console.Write(peca);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(" ");
            }
        }
    }
}
