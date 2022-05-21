namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }//acesso próprio e por subclasses
        public int qteMovimentos { get; protected set; }//acesso próprio e por subclasses
        public Tabuleiro tab { get; protected set; }//acesso próprio e por subclasses

        public Peca(Tabuleiro tab, Cor cor)//construtor
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
        public void decrementarQteMovimentos()//contabiliza movimentos da peça
        {
            this.qteMovimentos--;
        }
        public bool existeMovimentosPossiveis()//para saber se determinada peça poderá ser movida ao selecioná-la
        {
            bool[,] mat = movimentosPossiveis();

            //varre a matriz tabuleiro à procura de uma posição para qual a peça pode ser movimentada
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos)//verifica se posição passada como parâmetro é true na matriz de movimentos possíveis
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        abstract public bool[,] movimentosPossiveis();//método abstrato
    }
}
