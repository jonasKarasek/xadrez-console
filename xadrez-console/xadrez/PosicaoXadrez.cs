using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez//relação entre posição no padrão matricial e padrão de xadrez
    {

        public char coluna { get; set; }//A, B, C, D, E, F, G, H
        public int linha { get; set; }//1, 2, 3, 4, 5, 6, 7, 8

        public PosicaoXadrez(char coluna, int linha)//construtor da classe
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        public Posicao toPosicao()//converte padrão xadrez para padrão matricial
        {
            return new Posicao(8 - linha, coluna - 'a'); 
        }
        public override string ToString()//exibe no padrão xadrez. Ex: C7
        {
            return "" + coluna + linha;
        }
    }
}
