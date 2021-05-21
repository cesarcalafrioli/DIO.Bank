/*
Projeto DIO.Bank
Conta.cs
Autor = César Calafrioli
Data de criação = 20/05/2021
Última modificação = 20/05/2021

Classe pertencente ao projeto DIO.Bank que modela a informação da conta bancária do usuário
*/
using System;

namespace DIO.Bank
{
    internal class Conta
    {
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }


        // Sacar dinheiro
        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if ( this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("O saldo atual de {0} é R$ {1} ", this.Nome, this.Saldo);

            return true;
        }

        // Depositar dinheiro
        public void Depositar(double valorDeposito){

            // Adicionar uma verificação nesse método
            this.Saldo += valorDeposito;
            
            Console.WriteLine("Saldo atual de {0} é R$ {1} ", this.Nome, this.Saldo);

        }

        // Transfere dinheiro de uma conta para a outra
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if ( this.Sacar(valorTransferencia )){
                contaDestino.Depositar(valorTransferencia);

                Console.WriteLine("Transferência realizada com sucesso!");
                Console.WriteLine("Operação Finalizada");
            }
        }

        // Detalhes de cada conta bancária
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta :" + this.TipoConta + " | ";
            retorno += "Nome :" + this.Nome + " | ";
            retorno += "Saldo : R$" + this.Saldo + " | ";
            retorno += "Crédito : R$" + this.Credito;
            
            return retorno;
        }

    }
}