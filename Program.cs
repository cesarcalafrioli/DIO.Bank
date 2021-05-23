/*
Projeto DIO.Bank
Program.cs
Autor = César Calafrioli
Data de criação = 20/05/2021
Última modificação = 23/05/2021

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
                    case "6":
                        Saldo();
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
 
        }

        // Exibe na tela o menu
        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine("|                        DIO BANK                       |");
            Console.WriteLine("=========================================================");
            Console.WriteLine();
            Console.WriteLine("Opções:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Saldo");
            Console.WriteLine("X - Encerrar");
            Console.WriteLine();            
            Console.Write("Informe a opção desejada : ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        // Lista todas as contas cadastradas
        private static void ListarContas()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|           LISTAR         |");
            Console.WriteLine("----------------------------");


            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                //Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            
        }

        // Criar uma nova conta
        private static void InserirConta()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|         NOVA CONTA       |");
            Console.WriteLine("----------------------------");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            // Verifica se já existe alguma conta com o nome informado pelo usuário
            if ( contaExiste(entradaNome, 0, 2)){
                Console.WriteLine("Já existe uma conta com este nome");
                return;
            }

            Console.Write("Digite o saldo inicial: R$ ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: R$ ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(listaContas.Count, tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome
            );
       
            listaContas.Add(novaConta);
           
        }

        // Transfere o valor de uma conta para outra
        private static void Transferir()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|        TRANSFERIR        |");
            Console.WriteLine("----------------------------");

            // Interrompe se a lista estiver vazia
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            // Verifica se determinada conta de origem existe
            if ( !contaExiste(null, indiceContaOrigem, 1))
            {
                Console.WriteLine("Conta de origem inexistente");
                return;
            }

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            // Verifica se determinada conta de destino existe
            if ( !contaExiste(null, indiceContaDestino, 1))
            {
                Console.WriteLine("Conta de destino inexistente");
                return;
            }


            if ( indiceContaDestino == indiceContaOrigem ){
                Console.WriteLine("A conta de destino não deve ser a mesma da de origem.");
                return;
            }

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            if ( listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]) ){
                Console.WriteLine("Transferência realizada com sucesso!");
            } else {
                Console.WriteLine("Não foi possível realizar a transferência!");
            }
            
        }

        // Saca o valor da conta do usuário
        private static void Sacar()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|            SACAR         |");
            Console.WriteLine("----------------------------");

            // Interrompe se a lista estiver vazia
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            // Verifica se determinada conta existe
            if ( !contaExiste(null ,indiceConta, 1))
            {
                Console.WriteLine("Conta inexistente");
                return;
            }

            // Retorna o nome da conta
            Console.WriteLine("Nome do Cliente: {0} ", listaContas[indiceConta].mostrarNomeConta());


            Console.Write("Digite o valor a ser sacado : R$ ");
            double valorSaque = double.Parse(Console.ReadLine());

            // Realiza o saque
            listaContas[indiceConta].Sacar(valorSaque);

        }

        // Deposita o valor na conta do usuário
        private static void Depositar()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|         DEPOSITAR        |");
            Console.WriteLine("----------------------------");

            // Interrompe se a lista estiver vazia
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            // Verifica se a conta existe
            if ( !contaExiste(null, indiceConta, 1)){
                Console.WriteLine("Conta inexistente");
                return;
            }
            

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            if ( listaContas[indiceConta].Depositar(valorDeposito) ) {
                Console.WriteLine("Valor Depositado com sucesso!");
            } else {
                Console.WriteLine("Não foi possível realizar o depósito!");
            }
        }

        // Exibe o saldo do respectivo usuário
        private static void Saldo()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|            SALDO         |");
            Console.WriteLine("----------------------------");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            // Verifica se determinada conta existe
            if ( !contaExiste(null, indiceConta, 1) )
            {
                Console.WriteLine("Conta inexistente");
                return;
            }

            // Exibe o saldo
            Console.WriteLine(listaContas[indiceConta].mostrarSaldoConta());

        }

        // Verifica se a conta existe após o usuário digitar o número ou o nome da conta
        // Tipo de pesquisa -> 1 = numero da conta; 2 = nome da conta
        private static bool contaExiste(string nome, int numeroConta, int tipoPesquisa)
        {
            if ( tipoPesquisa == 1)
            {
                foreach (Conta c in listaContas)
                {
                        if ( c.mostraNumeroConta() == numeroConta){
                            return true;
                        }
                }
            } else if ( tipoPesquisa == 2 ) {
                foreach (Conta c in listaContas)
                {
                        if ( c.mostrarNomeConta() == nome){
                            return true;
                        }
                }

            }
            return false;
        }
    }
}
