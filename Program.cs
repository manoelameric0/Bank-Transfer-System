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

        public double GetContaBancaria()
        {
            return Saldo;
        }

        //Função para deposito

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine($"O valor {valor} é invalido. ");
            } else
            {
                Saldo += valor;
                Console.WriteLine("Deposito realizado com sucesso! ");
            }
        }

        // Função para saque
        public void Sacar(double valor)
        {
            if(Saldo - valor < 0)
            {
                Console.WriteLine("Erro! saldo insuficiente");
            } else
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso! ");
            }
        }
    }

    static void Main()
    {

        string[] sim = {"SIM", "SI", "S", "YES", "Y", "CLARO"};

        // Armazena as contas

        List<ContaBancaria> contas = new List<ContaBancaria>();

        Console.WriteLine("Quantas contas deseja criar? ");

        int quantidade = int.Parse(Console.ReadLine() ?? "0");

        for(int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Digite o nome da conta Nº {i + 1}");
            Console.WriteLine("Nome: ");

            string nome = Console.ReadLine() ?? "0";

            contas.Add(new ContaBancaria {Titular = nome, Id = GerarId()});
        }

        foreach (ContaBancaria p in contas)
        {
            Console.WriteLine($"Nome: {p.Titular} | ID: {p.Id}");
        }

        bool rodando = true;

        while(rodando)
        {
            Console.WriteLine("Selecione uma das opções: ");
            Console.WriteLine("1- Depositar..");
            Console.WriteLine("2- Sacar......");
            Console.WriteLine("3- Transferir.");
            Console.WriteLine("4- Sair.......");
            
            int escolha = int.Parse(Console.ReadLine() ?? "0");

            switch (escolha)
            {
                case 1:
                    if (escolha == 1)
                    {
                    OperarConta("DEPOSITO");
                    }
                    break;

                case 2:
                    if (escolha == 2)
                    {
                    OperarConta("SAQUE");
                    }
                    break;

                case 3:
                  if (escolha == 3)
                    {
                    Console.WriteLine("Digite o ID da conta: ");
                    int idCheck = int.Parse(Console.ReadLine() ?? "0");
                    ContaBancaria ContaSelecionada = ProcurarContaPorId(contas, idCheck);
                    
                    if(ContaSelecionada == null)
                        {
                            Console.WriteLine("Id não encontrado");
                        } else
                        {
                            Console.WriteLine("Digite o id da conta há depositar: ");
                            
                            
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Programa encerrado. ");
                    rodando = false;
                    break;

                default:
                    Console.WriteLine("Opção invalida. ");
                    rodando = false;
                    break;
            }
        }
    }

    private static Random rnd = new Random();

    public static int GerarId()
    {
        return rnd.Next(100, 200);
    }

    public static ContaBancaria ProcurarContaPorId(List<ContaBancaria> contas, int id)
    {
        foreach (ContaBancaria p in contas)
        {
            if (id == p.Id)
            {
                return p;
            } 
        }
        return null;
    }

    public static void OperarConta(List<ContaBancaria> contas, string tipoOperacao)
    {
        if (tipoOperacao == "SAQUE")
        {
            Console.WriteLine("Digite o ID da conta: ");
            int idCheck = int.Parse(Console.ReadLine() ?? "0");
            ContaBancaria ContaSelecionada = ProcurarContaPorId(contas, idCheck);
                            
            if(ContaSelecionada == null)
            {
            Console.WriteLine("Id não encontrado");
            } else
            {
            Console.WriteLine("Valor a sacar: ");
            double valor = double.Parse(Console.ReadLine() ?? "0");
            ContaSelecionada.Sacar(valor);
            }
        }

        if (tipoOperacao == "DEPOSITO")
        {
            Console.WriteLine("Digite o ID da conta: ");
            int idCheck = int.Parse(Console.ReadLine() ?? "0");
            ContaBancaria ContaSelecionada = ProcurarContaPorId(contas, idCheck);
                            
            if(ContaSelecionada == null)
            {
            Console.WriteLine("Id não encontrado");
            } else
            {
            Console.WriteLine("Valor a depositar: ");
            double valor = double.Parse(Console.ReadLine() ?? "0");
            ContaSelecionada.Depositar(valor);
            }
        }
    }
    public void Transferir(string id, double valor)
    {
        
    }
}