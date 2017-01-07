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
    public partial class FormRelatorios : Form
    {
        private List<Conta> contas;
        public FormRelatorios(List<Conta> contas)
        {
            this.contas = contas;
            InitializeComponent();
        }

        private void botaoLINQ_Click(object sender, EventArgs e)
        {
            var filtro = contas
                .Where(c => c.Saldo > 5000)
                .OrderBy(c => c.Titular.Nome)
                .ThenBy(c => c.NumeroConta);

            listaResultado.Items.Clear();
            foreach (var c in filtro)
            {
                listaResultado.Items.Add(c);
            }
        }

        private void FormRelatorios_Load(object sender, EventArgs e)
        {
            var saldoTotal = contas.Sum(x => x.Saldo);
            var maiorSaldo = contas.Max(x => x.Saldo);
            labelMaiorS.Text = maiorSaldo.ToString();
            labelSaldoTotal.Text = saldoTotal.ToString();
        }
    }
}
