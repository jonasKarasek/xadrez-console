namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }//acesso próprio e por subclasses
        public int qteMovimentos { get; protected set; }//acesso próprio e por subclasses
        public Tabuleiro tab { get; protected set; }//acesso próprio e por subclasses

        public Peca(Posicao posicao, Tabuleiro tab, Cor cor)
        {
            this.posicao = posicao;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }
    }
}
