namespace contaCorrente.ConsoleApp1
{
    public class Movimentacao
    {
        public decimal valor;
        public string tipo;

        public string LerMovimentacao()
        {
            return $"{tipo} - {valor.ToString("C2")}";
        }
    }

    public class ContaCorrente
    {
        public int id;
        public decimal saldo;
        public decimal limite;
        public Movimentacao[] movimentacoes;
        int contadorMovimentacao = 0;
    
        public void Depositar(decimal depositar)
        {
            saldo = saldo + depositar;

            Movimentacao novaMovimentacao = new Movimentacao();
            novaMovimentacao.valor = depositar;
            novaMovimentacao.tipo = "Credito";
            movimentacoes[contadorMovimentacao] = novaMovimentacao;
        }

        public void Sacar(decimal sacar)
        {
            if (sacar <= saldo + limite)
            {
                saldo -= sacar;

                Movimentacao novaMovimentacao = new Movimentacao();
                novaMovimentacao.valor = sacar;
                novaMovimentacao.tipo = "Debito";

                movimentacoes[contadorMovimentacao] = novaMovimentacao;
                contadorMovimentacao++;
            }

            else
            {
                Console.WriteLine("Quantia solicitada ultrapassa o saldo + limite");
            }
        }

        public void Transferencia(ContaCorrente destinatario, decimal quantia)
        {
            destinatario.Depositar(quantia);

            this.Sacar(quantia);
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("Extrato da Conta #" + this.id);
            Console.WriteLine("Saldo: " + this.saldo);

            for(int i = 0; i < movimentacoes.Length; i++)
            {
                Movimentacao movimentacaoAtual = movimentacoes[i];

                if (movimentacaoAtual != null)
                {
                    Console.WriteLine(movimentacaoAtual.LerMovimentacao());
                }
            }
        }
    }
}
