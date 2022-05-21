using tabuleiro;
using System;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)//construtor
        {

        }
        public override string ToString()
        {
            return "C";//exibição da peça no tabuleiro
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

            //acima+direita
            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //direita+acima
            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //acima+esquerda
            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //esquerda+acima
            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //abaixo+direita
            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //direita+abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //abaixo+esquerda
            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
            //esquerda+abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);//posição possível para este tipo de peça
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;//marca posição como possível
                

            return mat;
        }
    }
}