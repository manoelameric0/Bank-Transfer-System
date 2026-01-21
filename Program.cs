using System;
using System.Collections.Generic;
class Exercicio
{
    public class ContaBancaria
    {
        public string Titular { get; set; }
        public int Id;
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
        List<ContaBancaria> contas = new List<ContaBancaria>();
        
        int quantidade = int.Parse(Console.ReadLine());

        for(int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Digite o nome da conta {i + 1}");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            contas.Add(new ContaBancaria {Titular = nome, Id = GerarId()});
        }

        foreach (ContaBancaria p in contas)
        {
            Console.WriteLine($"Nome: {p.Titular}, Id: {p.Id}");
        }
    }

    private static Random rnd = new Random();

    public static int GerarId()
    {
        return rnd.Next(100, 200);
    }
}