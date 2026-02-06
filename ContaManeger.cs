using System;

namespace ContaBancaria;

public class ContaManeger
{
    List<ContaBancaria> contas = new();


    public void AddConta(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
            {
                Console.Write($"Nome do titular da conta {i + 1}: ");
                string nome = Console.ReadLine() ?? string.Empty;

                contas.Add(new ContaBancaria(nome));
            }
    }
}
