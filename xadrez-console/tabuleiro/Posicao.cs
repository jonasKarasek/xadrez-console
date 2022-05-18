namespace  tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        public void definirValores(int linha, int coluna)//igual construtor
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        public override string ToString() //exibir posição no padrão matricial a partir do objeto. Ex: (1, 2)
        {
            return "linha: " + linha + ", coluna: " + coluna;
        }
    }
}
