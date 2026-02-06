using System;
using System.Collections.Generic;
using ContaBancaria;

namespace SistemaBancario
{
    class Program
    {
        static void Main()
        {
            var manager = new ContaManeger();

            Console.Write("Quantas Contas deseja criar? ");
            int quantidade = manager.LerInt();

            manager.AddConta(quantidade);

            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Checar Contas");
                Console.WriteLine("5 - Sair");
                Console.Write("Opção: ");

                int opcao = manager.LerInt();

                switch (opcao)
                {
                    case 1:
                        manager.OperarDeposito(manager._contas);
                        break;

                    case 2:
                        manager.OperarSaque(manager._contas);
                        break;

                    case 3:
                        manager.OperarTransferencia(manager._contas);
                        break;

                    case 4:
                        manager.ExibirContas(manager._contas);
                        break;

                    case 5:
                        executando = false;
                        Console.WriteLine("Sistema encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }


    }
}
