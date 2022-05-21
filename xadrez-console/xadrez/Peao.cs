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
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }        
        public override bool[,] movimentosPossiveis()//retorna matriz xadrez com as posições para que este tipo de peça pode se mover
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//cópia limpa do tabuleiro

            Posicao pos = new Posicao(0, 0);//inicializa posição

            if (cor == Cor.Branco)//branco - movimento para cima
            {
                //MOVIMENTAÇÃO NORMAL
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível
                
                //MOVIMENTAÇÃO INICIAL DE 2 CASAS
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível

                //CAPTURAR PEÇAS
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível

                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível
            }
            else//preto - movimento para baixo
            {
                //MOVIMENTAÇÃO NORMAL
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível

                //MOVIMENTAÇÃO INICIAL DE 2 CASAS
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível

                //CAPTURAR PEÇAS
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível

                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;//marca posição como possível
            }

            return mat;
        }
    }
}