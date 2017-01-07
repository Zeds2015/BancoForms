using ContasBanco;

namespace Totalizadores
{
    public class TotalizadorSaldo
    {
        public double SaldoTotal { get; set; }

        public void Adiciona(Conta conta)
        {
            SaldoTotal += conta.Saldo;
        }   
    }
}
