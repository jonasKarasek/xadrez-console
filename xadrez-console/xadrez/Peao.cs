using tabuleiro;
using System;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)//construtor
        {

        }
        public override string ToString()
        {
            return "P";//exibição da peça no tabuleiro
        }
        private bool podeMover(Posicao pos)//destino da peça deve ser vazio ou conter peça inimiga
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()//retorna matriz xadrez com as posições para que este tipo de peça pode se mover
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//cópia limpa do tabuleiro

            Posicao pos = new Posicao(0, 0);//inicializa posição

            if(cor == Cor.Branco)
                //acima
                pos.definirValores(posicao.linha - 1, posicao.coluna);//posição possível para este tipo de peça
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível
                }
            else
                //abaixo
                pos.definirValores(posicao.linha + 1, posicao.coluna);//posição possível para este tipo de peça
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível
                }

            return mat;
        }
    }
}