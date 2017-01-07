namespace ContasBanco
{
    public class ContaCorrente:Conta
    {
        private static int contasCriadas;

        public ContaCorrente()
        {
            contasCriadas++;
        }
        public static int ProximaConta()
        {
            return contasCriadas;
        } 
    }
}
