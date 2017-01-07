using System;
using Errors;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContasBanco
{
    public abstract class Conta
    {
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get; set; }

        public virtual void Deposito(double valor)
        {
            if (valor > 0)
                Saldo += valor;
            else
                throw new ArgumentException();
        }
        public virtual bool Saque(double valor)
        {
            if (valor < 0)
                throw new ArgumentException();
            else if (Saldo < valor)
                throw new SaldoInsuficienteException();
            else
            {
                Saldo -= valor;
                return true;
            }
        }
        public override string ToString()
        {
            return "Titular: " + Titular;
        }
    }
}
