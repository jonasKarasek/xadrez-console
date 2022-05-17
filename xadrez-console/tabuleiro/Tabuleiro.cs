namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;//apenas esta classe altera as peças

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];//gera matriz de xadrez
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)//acesso a cada peça porque a matriz é privada
        {
            return pecas[pos.linha, pos.coluna];
        }
        public bool existePeca(Posicao pos)//verifica se a posição está ocupada
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        public bool posicaoValida(Posicao pos)//verifica se posição está dentro das dimensões do tabuleiro
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
                return false;

            return true;
        }
        public void validarPosicao(Posicao pos)//dispara msg
        {
            if(!posicaoValida(pos))
                throw new TabuleiroException("Posição inválida");
        }
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição");//dispara msg
            pecas[pos.linha, pos.coluna] = p;//coloca a peça na matriz de xadrez
            p.posicao = pos;//define a posição para a peça
        }
    }
}
