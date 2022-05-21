using tabuleiro;
using System;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)//construtor
        {

        }
        public override string ToString()
        {
            return "B";//exibição da peça no tabuleiro
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

            //direita+acima
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);//posição possível para este tipo de peça
            while (tab.posicaoValida(pos) && podeMover(pos))//while - este tipo de peça pode mover mais de uma casa por jogada
            {
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)//pára quando encontrar uma peça da mesma cor
                    break;
                //anda mais uma casa
                pos.linha--;
                pos.coluna++;
            }
            //direita+abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);//posição possível para este tipo de peça
            while (tab.posicaoValida(pos) && podeMover(pos))//while - este tipo de peça pode mover mais de uma casa por jogada
            {
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)//pára quando encontrar uma peça da mesma cor
                    break;
                //anda mais uma casa
                pos.linha++;
                pos.coluna++;
            }
            //esquerda+acima
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);//posição possível para este tipo de peça
            while (tab.posicaoValida(pos) && podeMover(pos))//while - este tipo de peça pode mover mais de uma casa por jogada
            {
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)//pára quando encontrar uma peça da mesma cor
                    break;
                //anda mais uma casa
                pos.linha--;
                pos.coluna--;
            }
            //esquerda+abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);//posição possível para este tipo de peça
            while (tab.posicaoValida(pos) && podeMover(pos))//while - este tipo de peça pode mover mais de uma casa por jogada
            {
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)//pára quando encontrar uma peça da mesma cor
                    break;
                //anda mais uma casa
                pos.linha++;
                pos.coluna--;
            }
            return mat;
        }
    }
}