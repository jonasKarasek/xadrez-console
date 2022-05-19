using tabuleiro;
using System;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";//exibição da peça no tabuleiro
        }

        private bool podeMover(Posicao pos)//destino da peça está vazio ou contém peça inimiga
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()//retorna matriz xadrez com as posições para que este tipo de peça pode se mover
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//cópia limpa do tabuleiro

            Posicao pos = new Posicao(0, 0);//inicializa posição

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);//posição possível para este tipo de peça
            while(tab.posicaoValida(pos) && podeMover(pos))//while - este tipo de peça pode mover mais de uma casa por jogada
            {
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)//pára quando encontrar uma peça da mesma cor
                    break;
                pos.linha--;//anda mais uma casa
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.coluna++;
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.coluna--;
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha++;
            }
            return mat;
        }
    }
}
