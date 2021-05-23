/*
Projeto DIO.Bank
Conta.cs
Autor = César Calafrioli
Data de criação = 20/05/2021
Última modificação = 23/05/2021

Classe pertencente ao projeto DIO.Bank que modela a informação da conta bancária do usuário
*/
using System;

namespace DIO.Bank
{
    internal class Conta
    {
        private int NumeroConta { get; set; }

        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private TipoConta TipoConta { get; set; }

        public Conta(int numeroConta, TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.NumeroConta = numeroConta;
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

        // Deposita o valor na conta do usuário
        public bool Depositar(double valorDeposito){

            if ( valorDeposito <= 0 ){
                return false;
            }

            this.Saldo += valorDeposito;
            
            Console.WriteLine("Saldo atual de {0} é R$ {1} ", this.Nome, this.Saldo);

            return true;

        }

        // Transfere dinheiro de uma conta para a outra
        public bool Transferir(double valorTransferencia, Conta contaDestino)
        {
            if ( this.Sacar(valorTransferencia )){
                contaDestino.Depositar(valorTransferencia);
                return true;
            } else {
                return false;
            }

        }

        // Retorna o nome de determinadaconta
        public string mostrarNomeConta(){

            return this.Nome;

        }

        // retorna o id de determinada conta
        public int mostraNumeroConta(){

            return this.NumeroConta;
        }

        // Retorna o saldo e crédito de determinado usuário
        public string mostrarSaldoConta(){

            string saldo = "Cliente : " + this.Nome + "\n";
            saldo += "Tipo de conta : " + this.TipoConta + "\n";
            saldo += "Saldo : R$ " + this.Saldo + "\n";
            saldo += "Crédito : R$ " + this.Credito + "\n";

            return saldo;

        }

        // Detalhes de cada conta bancária para a lista de contas
        public override string ToString()
        {
            string retorno = "";
            retorno += "Conta : " + this.NumeroConta + " | ";
            retorno += "Tipo de conta : " + this.TipoConta + " | ";
            retorno += "Nome : " + this.Nome + " | ";
            retorno += "Saldo : R$ " + this.Saldo + " | ";
            retorno += "Crédito : R$ " + this.Credito;
            
            return retorno;
        }

    }
}