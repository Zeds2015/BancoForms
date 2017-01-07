using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;

namespace Totalizadores
{
    public class TotalizadorTributos
    {
        public double Total { get; set; }

        public void Acumula(ITributavel tributavel)
        {
            Total += tributavel.CalculaTributo();
        }

    }
}
