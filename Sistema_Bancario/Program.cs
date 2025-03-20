namespace Sistema_Bancario
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1C = new ContaCorrente(1, "Alex", 0.00);
            conta1C.ExibirSaldo();
            conta1C.Depositar(200);
            conta1C.ExibirSaldo();
            conta1C.Sacar(200);
            conta1C.ExibirSaldo();

            ContaPoupanca conta2P = new ContaPoupanca(1, "Joao", 1500.00);
            conta2P.ExibirSaldo();
            conta2P.Depositar(200);
            conta2P.ExibirSaldo();
            conta2P.Sacar(200);
            conta2P.ExibirSaldo();

            Console.WriteLine("\nAperte 'Enter' para continuar");
            Console.ReadLine();
        }
    }
}