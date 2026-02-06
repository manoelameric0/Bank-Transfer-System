using System;

namespace ContaBancaria;

public class ContaManeger
{
    List<ContaBancaria> contas = new();
    public List<ContaBancaria> _contas
    {
        get
        {
            return contas;
        }
    }


    public void AddConta(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"Nome do titular da conta {i + 1}: ");
            string nome = Console.ReadLine() ?? string.Empty;

            contas.Add(new ContaBancaria(nome));
        }
    }

    // ================= OPERAÇÕES =================
    public void OperarDeposito(List<ContaBancaria> contas)
    {
        ContaBancaria? conta = SolicitarConta(contas);
        if (conta == null) return;

        Console.Write("Valor do depósito: ");
        double valor = LerDouble();

        Console.WriteLine(
            conta.Depositar(valor)
                ? "Depósito realizado com sucesso."
                : "Valor inválido."
        );

        ExibirSaldo(conta);
    }

    public void OperarSaque(List<ContaBancaria> contas)
    {
        ContaBancaria? conta = SolicitarConta(contas);
        if (conta == null) return;

        Console.Write("Valor do saque: ");
        double valor = LerDouble();

        Console.WriteLine(
            conta.Sacar(valor)
                ? "Saque realizado com sucesso."
                : "Saldo insuficiente ou valor inválido."
        );

        ExibirSaldo(conta);
    }

    public void OperarTransferencia(List<ContaBancaria> contas)
    {
        Console.Write("ID da conta de origem: ");
        int origemId = LerInt();

        Console.Write("ID da conta de destino: ");
        int destinoId = LerInt();

        Console.Write("Valor da transferência: ");
        double valor = LerDouble();

        ContaBancaria? origem = BuscarConta(contas, origemId);
        ContaBancaria? destino = BuscarConta(contas, destinoId);

        if (origem == null || destino == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine(
            origem.Transferir(destino, valor)
                ? "Transferência realizada com sucesso."
                : "Erro: saldo insuficiente ou valor inválido."
        );
    }

    // ================= UTILITÁRIOS =================
    public ContaBancaria? SolicitarConta(List<ContaBancaria> contas)
    {
        Console.Write("ID da conta: ");
        int id = LerInt();

        ContaBancaria? conta = BuscarConta(contas, id);

        if (conta == null)
            Console.WriteLine("Conta não encontrada.");

        return conta;
    }

    public ContaBancaria? BuscarConta(List<ContaBancaria> contas, int id)
    {
        return contas.Find(c => c.Id == id);
    }

    public void ExibirContas(List<ContaBancaria> contas)
    {
        Console.WriteLine("\n=== CONTAS CADASTRADAS ===");

        if (contas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        foreach (var conta in contas)
        {
            Console.WriteLine(conta);
        }
    }

    public void ExibirSaldo(ContaBancaria conta)
    {
        Console.WriteLine($"Saldo atual: R$ {conta.ObterSaldo():F2}");
    }

    // ================= LEITURA SEGURA ==================
    public int LerInt()
    {
        int valor;

        while (!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.Write("Entrada inválida. Digite um número inteiro maior que ZERO: ");
        }

        return valor;
    }

    public double LerDouble()
    {
        double valor;

        while (!double.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Entrada inválida. Digite um número válido: ");
        }

        return valor;
    }
}

// ================= CLASSE CONTA ==================

class ContaBancaria
{


    public bool Depositar(double valor)
    {
        if (valor <= 0) return false;

        Saldo += valor;
        return true;
    }

    public bool Sacar(double valor)
    {
        if (valor <= 0 || Saldo < valor) return false;

        Saldo -= valor;
        return true;
    }

    public bool Transferir(ContaBancaria destino, double valor)
    {
        if (!Sacar(valor)) return false;

        destino.Depositar(valor);
        return true;
    }

    public double ObterSaldo()
    {
        return Saldo;
    }

    public override string ToString()
    {
        return $"Titular: {Titular} | ID: {Id} | Saldo: R$ {Saldo:F2}";
    }
}

