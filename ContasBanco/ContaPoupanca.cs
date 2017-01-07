using System;
using Contratos;

namespace ContasBanco
{
    public class ContaPoupanca:Conta,ITributavel
    {
        private static int contasCriadas;

        public ContaPoupanca()
        {
            contasCriadas++;
        }

        public double CalculaTributo()
        {
            return Saldo * 0.03;
        }

        public override void Deposito(double valor)
        {
            base.Deposito(valor-(valor*0.05));
        }
        public override bool Saque(double valor)
        {
            return base.Saque(valor+(valor*0.06));
        }
        public static int ProximaConta()
        {
            return contasCriadas;
        }
    }
}
