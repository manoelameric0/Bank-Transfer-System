using System;

namespace ContaBancaria;

public class ContaBancaria
{
    private static readonly Random Random = new();

    public int Id { get; }
    public string Titular { get; }
    public double Saldo {get; private set;}

    public ContaBancaria(string titular)
    {
        Titular = titular;
        Id = Random.Next(100, 200);
        Saldo = 0;
    }

    public ContaBancaria()
    {
        
    }

    public double DepSacSaldo
    {
        set
        {
            Saldo = value;
        }
        get
        {
            return Saldo;
        }
    }
}
