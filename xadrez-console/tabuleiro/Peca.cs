namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }//acesso próprio e por subclasses
        public int qteMovimentos { get; protected set; }//acesso próprio e por subclasses
        public Tabuleiro tab { get; protected set; }//acesso próprio e por subclasses

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;//peça é gerada sem posição inicial
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()//contabiliza movimentos da peça
        {
            this.qteMovimentos++;
        }

        abstract public bool[,] movimentosPossiveis();
    }
}
