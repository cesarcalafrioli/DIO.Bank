/*
Projeto DIO.Bank
Program.cs
Autor = César Calafrioli
Data de criação = 20/05/2021
Última modificação = 22/05/2021

Projeto do laboratório de desenvolvimento .net
*/
using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        // Tabela detalhada de cada conta registrada no banco
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
           // Lê a opção do usuário
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X" )
            {
                Console.Clear();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        ObterOpcaoUsuario();
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos a sua preferência.");
            Console.ReadLine();
        }

        // Transfere o valor de uma conta para outra
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            if ( listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]) ){
                Console.WriteLine("Transferência realizada com sucesso!");
            } else {
                Console.WriteLine("Não foi possível realizar a transferência!");
            }
            
        }

        // Deposita o valor na conta do usuário
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            if ( listaContas[indiceConta].Depositar(valorDeposito) ) {
                Console.WriteLine("Valor Depositado com sucesso!");
            } else {
                Console.WriteLine("Não foi possível realizar o depósito!");
            }
        }

        // Criar uma nova conta
        private static void InserirConta()
        {

            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome
            );
       
            listaContas.Add(novaConta);
           
        }

        // Lista as contas cadastradas
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            
        }

        // Exibe na tela a lista de opções
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Opções:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Encerrar");
            Console.WriteLine();            
            Console.WriteLine("Informe a opção desejada :");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        // Saca o valor da conta do usuário
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado : ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

        }
    }
}
