using System;
class Exercicio
{
    public class ContaBancaria
    {
        public string Titular { get; set; }
        private int Id;
        private double Saldo;

        public ContaBancaria(string titular, int id, double saldo)
        {
            Titular = titular;
            Id = id;
            Saldo = saldo;
        }

        public ContaBancaria()
        {
            Titular = "";
            Id = 0;
            Saldo = 0;
        }

    }

    static void Main()
    {
        int quantidade = int.Parse(Console.ReadLine());

        for(int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Digite o nome da conta {i + 1}");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            ContaBancaria conta = CriarConta(nome, GerarId());
        }
    }

    public static ContaBancaria CriarConta(string nome, int id)
    {
        return new ContaBancaria(nome, id, 0);
    }

    private static Random rnd = new Random();

    public static int GerarId()
    {
        return rnd.Next(100, 199);
    }
}