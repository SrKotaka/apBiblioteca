using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace apBiblioteca_22129_22130.UI
{
    public partial class FrmLivro : Form
    {
        public FrmLivro()
        {
            InitializeComponent();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new LivroBLL();
                dgvLivro.DataSource = bll.SelecionarLivros();
                dgvLivro.Columns[0].HeaderText = "Identificação";
                dgvLivro.Columns[1].HeaderText = "Código";
                dgvLivro.Columns[2].HeaderText = "Título";
                dgvLivro.Columns[3].HeaderText = "Autor(es)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var livro = new Livro(0, "", "", "");
            livro.CodigoLivro = txtCodigoLivro.Text;
            livro.TituloLivro = txtTituloLivro.Text;
            livro.AutorLivro = txtAutorLivro.Text;
            try
            {
                var bll = new LivroBLL();
                bll.NovoLivro(livro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var livro = new Livro(int.Parse(txtIdLivro.Text), txtCodigoLivro.Text, txtTituloLivro.Text, txtAutorLivro.Text);
            try
            {
                var bll = new LivroBLL();
                bll.AlterarLivro(livro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", "");
            try
            {
                var bll = new LivroBLL();
                bll.ExcluirLivro(livro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            var livro = new Livro(0, codigo, "", "");
            try
            {
                var bll = new LivroBLL();
                livro = bll.SelecionarLivroPorCodigo(codigo);
                txtIdLivro.Text = livro.IdLivro.ToString();
                txtCodigoLivro.Text = livro.CodigoLivro;
                txtTituloLivro.Text = livro.TituloLivro;
                txtAutorLivro.Text = livro.AutorLivro;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }
    }
}
