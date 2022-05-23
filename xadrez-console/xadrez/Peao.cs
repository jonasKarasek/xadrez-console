using tabuleiro;
using System;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)//construtor
        {
            this.partida = partida;
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

                //enPassant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1)
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant);
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1)
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) ;
                    mat[direita.linha - 1, direita.coluna] = true;
                }
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

                //enPassant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1)
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant) ;
                    mat[esquerda.linha + 1, esquerda.coluna] = true;

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1)
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant) ;
                    mat[direita.linha + 1, direita.coluna] = true;
                }
            }

            return mat;
        }
    }
}