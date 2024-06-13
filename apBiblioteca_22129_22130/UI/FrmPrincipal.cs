using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca_22129_22130.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        FrmLivro frmLivro = null;
        FrmLeitor frmLeitor = null;
        FrmOperacoes frmOperacoes = null;

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");
            else
            {
                frmLivro = new UI.FrmLivro();
                frmLivro.banco = txtBanco.Text;
                frmLivro.usuario = txtUsuario.Text;
                frmLivro.senha = txtSenha.Text;
                frmLivro.Show();
            }
        }

    }
}
