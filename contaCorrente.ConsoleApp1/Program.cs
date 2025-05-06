namespace contaCorrente.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();

            conta1.id = 1;
            conta1.saldo = 1000;
            conta1.limite = 0;
            conta1.movimentacoes = new Movimentacao[1000000];

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200);

            ContaCorrente conta2 = new ContaCorrente();

            conta2.id = 2;
            conta2.saldo = 300;
            conta2.limite = 0;
            conta2.movimentacoes = new Movimentacao[1000000];

            conta1.Transferencia(conta2, 400);

            conta1.ExibirExtrato();

            Console.WriteLine();

            conta2.ExibirExtrato();
        }
    }
}
