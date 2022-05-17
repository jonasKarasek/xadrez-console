﻿namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }//acesso próprio e por subclasses
        public int qteMovimentos { get; protected set; }//acesso próprio e por subclasses
        public Tabuleiro tab { get; protected set; }//acesso próprio e por subclasses

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }
    }
}
