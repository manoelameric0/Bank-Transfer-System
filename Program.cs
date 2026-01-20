using System;

class Exercicio
{
    class ContaBancaria
    {
        public string Titular { get; set; }
        private int Numero;
        private double Saldo;

        public ContaBancaria(string titular, int numero, double saldo)
        {
            Titular = titular;
            Numero = numero;
            Saldo = saldo;
        }

        public ContaBancaria()
        {
            Titular = "";
            Numero = 0;
            Saldo = 0;
        }

    }

    static void Main()
    {
        Console.WriteLine();
    }

    public static ContaBancaria CriarConta(string nome, int numero)
    {
        return new ContaBancaria(nome, numero, 0);
    }

    public static int GerarNumero()
    {
        Random rnd = new Random();
        int numero = rnd.Next(100, 199);
        return numero;
    }
}