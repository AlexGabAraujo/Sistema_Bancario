using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(int numeroConta, string titular, double saldo) : base(numeroConta, titular, saldo)
        {
            BonusDeposito = 0.05;
            Tipo = 2;
        }
    }
}
