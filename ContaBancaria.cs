using System;

namespace ContaBancaria;

public class ContaBancaria
{
    private static readonly Random Random = new();

    public int Id { get; }
    public string Titular { get; }
    public double Saldo { get; private set; }

    public ContaBancaria(string titular)
    {
        Titular = titular;
        Id = Random.Next(100, 200);
        Saldo = 0;
    }

    public ContaBancaria()
    {

    }

    public double ObterSaldo()
    {
        return Saldo;
    }

    public override string ToString()
    {
        return $"Titular: {Titular} | ID: {Id} | Saldo: R$ {Saldo:F2}";
    }

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

        Depositar(valor);        
        return true;
    }
}
