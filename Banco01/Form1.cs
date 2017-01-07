using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Totalizadores;
using Errors;
using ContasBanco;

namespace Banco01
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Conta> dicionario;
        private List<Conta> lista;
        private Conta conta;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string nome = "Mateus";
            int idade = 18;
            string txt = string.Format("Nome: {0} e Idade: {1}", nome, idade);
            MessageBox.Show(txt);
            dicionario = new Dictionary<string, Conta>();
            lista = new List<Conta>();
            textoImpostos.Enabled = 
            textoSaldo.Enabled = textoNumeroConta.Enabled = textoTitular.Enabled = false;
            if(!(lista.Count == 0))
            {
                var filtradas = lista.Where((Conta conta) => { return conta.Saldo > 2000; });
                foreach (var c in filtradas)
                {
                    MessageBox.Show(c.Titular.Nome + " fodão");
                }
            }
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            double valorDepositado = Convert.ToDouble(textoValor.Text);
            conta.Deposito(valorDepositado);
            textoSaldo.Text = conta.Saldo.ToString();
            MessageBox.Show("Sucesso!!!");
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            try
            {
                double valorRetirado = Convert.ToDouble(textoValor.Text);
                conta.Saque(valorRetirado);
                textoSaldo.Text = conta.Saldo.ToString();
                MessageBox.Show("Sucesso!!!");
            }
            catch(SaldoInsuficienteException)
            {
                MessageBox.Show("Saldo Insuficiente");
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Não pode sacar valor negativo");
            }
        }
        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indice = comboContas.SelectedIndex;
            conta = lista[indice];
            textoSaldo.Text = conta.Saldo.ToString();
            textoNumeroConta.Text = conta.NumeroConta.ToString();
            textoTitular.Text = conta.Titular.Nome;
        }

        public void AdicionaConta(Conta conta)
        {
            lista.Add(conta);
            comboContas.Items.Add(conta);
            dicionario.Add(conta.Titular.Nome, conta);
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formulario = new FormCadastroConta(this);
            formulario.ShowDialog();

        }

        private void botaoCalculaImpostos_Click(object sender, EventArgs e)
        {
            TotalizadorTributos tributos = new TotalizadorTributos();
            foreach (var conta in lista)
            {
                if(conta is ContaPoupanca)
                {
                    var poup = (ContaPoupanca)conta;
                    tributos.Acumula(poup);
                }
                else if(conta is ContaInvestimento)
                {
                    var invs = (ContaInvestimento)conta;
                    tributos.Acumula(invs);
                }
                textoImpostos.Text = tributos.Total.ToString();
            }
        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {
            if(!(lista.Count == 0))
            {
                if (dicionario.ContainsKey(textoNomeTitular.Text))
                {
                        conta = dicionario[textoNomeTitular.Text];
                        textoSaldo.Text = conta.Saldo.ToString();
                        textoNumeroConta.Text = conta.NumeroConta.ToString();
                        textoTitular.Text = conta.Titular.Nome;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var relatorio = new FormRelatorios(lista);
            relatorio.Show();
        }
    }
}
