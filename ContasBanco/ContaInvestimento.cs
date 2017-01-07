using Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBanco
{
    public class ContaInvestimento :Conta, ITributavel
    {
        public double CalculaTributo()
        {
            return Saldo * 0.02;
        }
    }
}
