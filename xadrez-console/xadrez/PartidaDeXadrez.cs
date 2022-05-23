using System;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;//apenas esta classe acessa a coleção
        private HashSet<Peca> capturadas;//apenas esta classe acessa a coleção
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()//construtor
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            inicioPecas();
        }
        public Peca executaMovimento(Posicao origem, Posicao destino)//movimento de peça
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);//armazenar peças capturadas
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            //roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tab.retirarPeca(origemTorre);
                torre.incrementarQteMovimentos();
                tab.colocarPeca(torre, destinoTorre);
            }
            //roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tab.retirarPeca(origemTorre);
                torre.incrementarQteMovimentos();
                tab.colocarPeca(torre, destinoTorre);
            }

            //enPassant
            if (p is Peao)
            {
                Posicao posPeao; 
                
                if (origem.coluna != destino.coluna && pecaCapturada == null)
                {
                    if (p.cor == Cor.Branco)
                        posPeao = new Posicao(destino.linha + 1, destino.coluna);
                    else
                        posPeao = new Posicao(destino.linha - 1, destino.coluna);

                    pecaCapturada = tab.retirarPeca(posPeao);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        //utilizada para movimentos que colocam a própria peça em xeque
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

            //roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tab.retirarPeca(destinoTorre);
                torre.decrementarQteMovimentos();
                tab.colocarPeca(torre, origemTorre);
            }
            //roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tab.retirarPeca(destinoTorre);
                torre.decrementarQteMovimentos();
                tab.colocarPeca(torre, origemTorre);
            }

            //enPassant
            if(p is Peao)
            {
                if(origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant)
                {
                    Peca peao = tab.retirarPeca(destino);
                    Posicao posPeao;
                    if(p.cor == Cor.Branco)
                        posPeao = new Posicao(3, destino.coluna);
                    else
                        posPeao = new Posicao(4, destino.coluna);

                    tab.colocarPeca(peao, posPeao);
                }    
            }
        }
        public void realizaJogada(Posicao origem, Posicao destino)//jogada do jogador
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual))//jogada volta se coloca o próprio jogador em xeque
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = tab.peca(destino);

            //promocao
            if (p is Peao)
            {
                if ((p.cor == Cor.Branco && destino.linha == 0) || (p.cor == Cor.Preto && destino.linha == 7))
                {
                    p.tab.retirarPeca(destino);
                    pecas.Remove(p);
                    Peca pecaPromocao;
                    Console.WriteLine();
                    Console.WriteLine("Digite o número correposndente à peça que seu peão será transformado: ");
                    Console.WriteLine("1 - Bispo");
                    Console.WriteLine("2 - Cavalo");
                    Console.WriteLine("3 - Rainha");
                    Console.WriteLine("4 - Torre");
                    int peca = int.Parse(Console.ReadLine());
                    switch (peca)
                    {
                        case 1:
                            pecaPromocao = new Bispo(tab, p.cor);
                            tab.colocarPeca(pecaPromocao, destino);
                            pecas.Add(pecaPromocao);
                            break;

                        case 2:
                            pecaPromocao = new Cavalo(tab, p.cor);
                            tab.colocarPeca(pecaPromocao, destino);
                            pecas.Add(pecaPromocao);
                            break;

                        case 3:
                            pecaPromocao = new Rainha(tab, p.cor);
                            tab.colocarPeca(pecaPromocao, destino);
                            pecas.Add(pecaPromocao);
                            break;
                        
                        case 4:
                            pecaPromocao = new Torre(tab, p.cor);
                            tab.colocarPeca(pecaPromocao, destino);
                            pecas.Add(pecaPromocao);
                            break;
                        default:
                            pecaPromocao = new Rainha(tab, p.cor);
                            tab.colocarPeca(pecaPromocao, destino);
                            pecas.Add(pecaPromocao);
                            break;
                    }
                }
            }
            
            if (estaEmXeque(adversaria(jogadorAtual)))//ajusta xeque
                xeque = true;
            else
                xeque = false;

            if (testeXequemate(adversaria(jogadorAtual)))
                terminada = true;
            else
            {
                turno++;
                mudaJogador();
            }
            //enPassant
            if(p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
                vulneravelEnPassant = p;
            else
                vulneravelEnPassant = null;
        }
        public void validarPosicaoDeOrigem(Posicao pos)//validação - A peça pode ser retirada de onde está?
        {
            if(tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição escolhida!\nAperte enter para continuar...");
            if(jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("A peça escolhida não é tua.\nAperte enter para continuar...");
            if(!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida.\nAperte enter para continuar...");
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)//validação - A peça pode ser colocada na posição escolhida?
        {
            if(!tab.peca(origem).movimentoPossivel(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }
        private void mudaJogador()//alterna jogadores a cada jogada
        {
            if (jogadorAtual == Cor.Branco)
                jogadorAtual = Cor.Preto;
            else
                jogadorAtual = Cor.Branco;
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)//coleção de peças fora de jogo para determina cor
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                    aux.Add(x);
            }

            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)//coleção de peças em jogo para determinada cor
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                    aux.Add(x);
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor adversaria(Cor cor)//determina a cor adversária
        {
            if (cor == Cor.Branco)
                return Cor.Preto;
            else
                return Cor.Branco;
        }
        private Peca rei(Cor cor)//encontra rei da cor
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                    return x;
            }
            return null;//não deve retornar isso porque os reis estão no tabuleiro enquanto a partida não terminar
        }
        public bool estaEmXeque(Cor cor)//verifica se o rei da cor está em xeque
        {
            Peca R = rei(cor);

            if (R == null)
                throw new TabuleiroException("Não tem Rei " + cor + "no tabuleiro!");

            foreach(Peca x in pecasEmJogo(adversaria(cor)))//para cada peça da cor adversária
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])//posição do rei - se estiver nos movimentos possíveis
                    return true;//então está em xeque
            }
            return false;//caso contrário não está em xeque
        }

        public bool testeXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
                return false;

            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();

                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            //permite ao programador usar as coordenadas padrão xadrez invés do padrão matricial
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);//adiciona peça à coleção de peças do jogo
        }
        private void inicioPecas()//posiciona as peças na configuração inicial da partida
        {
            //Peças Brancas
            //peões
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branco, this));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branco, this));
            //segunda fileira de peças
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branco));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branco));
            colocarNovaPeca('d', 1, new Rainha(tab, Cor.Branco));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branco, this));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branco));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branco));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branco));

            //Peças Pretas
            //peões
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preto, this));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preto, this));
            //segunda fileira de peças
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preto));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preto));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preto));
            colocarNovaPeca('d', 8, new Rainha(tab, Cor.Preto));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preto, this));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preto));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preto));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preto));
        }
    }
}
