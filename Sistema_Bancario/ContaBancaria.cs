using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    public class ContaBancaria
    {
        private int _numeroConta;
        private string _titular;
        private double _saldo;
        private int _taxaSaque = 0;
        private double _bonusDeposito = 0;
        private int _tipo = 0;

        public ContaBancaria(int numeroConta, string titular, double saldo)
        {
            this._numeroConta = numeroConta;
            this._titular = titular;
            this._saldo = saldo;

        }

        public int NumeroConta
        {
            get { 
                return _numeroConta; 
            }
            set { 
                if(_numeroConta == null) {
                    Console.WriteLine("O numero não pode ser nulo");
                }
                else
                {
                    _numeroConta = value;
                }
            }
        }

        public string Titular
        {
            get
            {
                return _titular;
            }
            set
            {
                _titular = value;
            }
        }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
            }
        }

        public int TaxaSaque
        {
            get
            {
                return _taxaSaque;
            }
            set
            {
                _taxaSaque = value;
            }
        }

        public double BonusDeposito
        {
            get
            {
                return _bonusDeposito;
            }
            set
            {
                _bonusDeposito = value;
            }
        }

        public int Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }

        public void Depositar(double valor)
        {
            Saldo += (valor + valor * BonusDeposito);
            Console.WriteLine("Depósito realizado com Sucesso!");
        }

        public void Sacar(double valor)
        {
            if((valor + TaxaSaque) > Saldo )
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
            else
            {
                Saldo -= (valor + TaxaSaque);
                Console.WriteLine("Saque realizado com Sucesso!");
            }
        }

        public void ExibirSaldo()
        {
            if(Tipo == 1)
            {
                Console.WriteLine($"Conta Corrente - {Titular} | Saldo: R$ {Saldo}");
            }
            else
            {
                Console.WriteLine($"Conta Poupança - {Titular} | Saldo: R$ {Saldo}");
            }
        }
    }
}
