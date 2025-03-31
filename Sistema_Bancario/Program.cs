﻿using System;
using System.Collections.Generic;

namespace Sistema_Bancario
{
    public class Program
    {
        static List<ContaBancaria> contas = new List<ContaBancaria>();

        static void Main(string[] args)
        {
            try
            {
                MostrarMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
                Console.WriteLine("\nAperte 'Enter' Para Tentar Novamente.");
                Console.ReadLine();
                Console.Clear();
                MostrarMenu();
            }
        }

        private static void MostrarMenu()
        {
            int opcao;

            do
            {
                Console.WriteLine("""
                -------------------MENU-------------------
                Escolha uma opção:

                1- Adicionar Nova Conta.
                2- Realizar um Depósito.
                3- Realizar um Saque.
                4- Visualizar Todas as Contas.
                5- Procurar uma Conta.
                6- Sair.

                """);

                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                Console.WriteLine("------------------------------------------");

                switch (opcao)
                {
                    case 1:
                        AdicionarConta();
                        break;
                    case 2:
                        RealizarDeposito();
                        break;
                    case 3:
                        RealizarSaque();
                        break;
                    case 4:
                        ExibirTodasContas();
                        break;
                    case 5:
                        ProcurarConta();
                        break;
                    case 6:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nAperte 'Enter' Para Tentar Novamente.");
                Console.ReadLine();
                Console.Clear();

            } while (opcao != 6);
        }


        private static void AdicionarConta()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Titular: ");
            string titular = Console.ReadLine();
            Console.Write("Saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());
            Console.Write("Tipo (1- Corrente, 2- Poupança): ");
            int tipo = int.Parse(Console.ReadLine());

            ContaBancaria novaConta = tipo == 1 ? new ContaCorrente(numero, titular, saldo) : new ContaPoupanca(numero, titular, saldo);
            contas.Add(novaConta);
            Console.WriteLine("\nConta adicionada com sucesso");
        }

        private static void RealizarDeposito()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            ContaBancaria conta = contas.Find(c => c.NumeroConta == numero);
            if (conta != null)
            {
                Console.Write("Valor do depósito: ");
                double valor = double.Parse(Console.ReadLine());
                conta.Depositar(valor);
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }

        private static void RealizarSaque()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            ContaBancaria conta = contas.Find(c => c.NumeroConta == numero);
            if (conta != null)
            {
                Console.Write("Valor do saque: ");
                double valor = double.Parse(Console.ReadLine());
                conta.Sacar(valor);
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }

        private static void ExibirTodasContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (var conta in contas)
            {
                conta.ExibirSaldo();
            }
        }

        private static void ProcurarConta()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            ContaBancaria conta = contas.Find(c => c.NumeroConta == numero);
            if (conta != null)
            {
                conta.ExibirSaldo();
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }
    }
}
