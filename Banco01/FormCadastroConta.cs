using ContasBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco01
{
    public partial class FormCadastroConta : Form
    {
        private Form1 formPrincipal;
        private Conta conta;
        private HashSet<string> devedores;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void botaoCadastrar_Click(object sender, EventArgs e)
        {
            conta.NumeroConta = Convert.ToInt32(textoNumero.Text);
            conta.Titular = new Cliente(textoTitular.Text);

            if (devedores.Contains(conta.Titular.Nome))
                MessageBox.Show("Infelizmente não podemos completar o cadastro!!!");
            else
            formPrincipal.AdicionaConta(conta);
            this.Hide();
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            devedores = new HashSet<string>();
            for (int i = 0; i < 30000; i++)
            {
                devedores.Add("devedores "+i);
            }
            textoNumero.Enabled = false;
        }

        private void radioCC_CheckedChanged(object sender, EventArgs e)
        {
            conta = new ContaCorrente();
            textoNumero.Text = ContaCorrente.ProximaConta().ToString();
            radioCP.Hide();
        }

        private void radioCP_CheckedChanged(object sender, EventArgs e)
        {
            conta = new ContaPoupanca();
            textoNumero.Text = ContaPoupanca.ProximaConta().ToString();
            radioCC.Hide();
        }
    }
}
