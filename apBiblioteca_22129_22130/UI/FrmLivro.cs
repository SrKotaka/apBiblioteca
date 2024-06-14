using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace apBiblioteca_22129_22130.UI
{
    public partial class FrmLivro : Form
    {
        public string banco, usuario, senha;

        private void btnExibir_Click(object sender, EventArgs e)
        {
            LivroBLL bll = new LivroBLL(banco, usuario, senha);
            dgvLivro.DataSource = bll.SelecionarLivros();

            // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados
            dgvLivro.AutoGenerateColumns = true;
            dgvLivro.BindingContext = new BindingContext();

            dgvLivro.AutoResizeColumns();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodigoLivro.Text == "" || txtTituloLivro.Text == "" || txtAutorLivro.Text == "")
                MessageBox.Show("Informações ausentes!");
            else
            {
                try
                {
                    Livro livro = new Livro(0, "", "", "");
                    livro.CodigoLivro = txtCodigoLivro.Text;
                    livro.TituloLivro = txtTituloLivro.Text;
                    livro.AutorLivro = txtAutorLivro.Text;
                    try
                    {
                        LivroBLL bll = new LivroBLL(banco, usuario, senha);
                        bll.IncluirLivro(livro);
                        MessageBox.Show("Inclusão feita com sucesso!");

                        Livro l = bll.ListarLivroPorCodigo(txtCodigoLivro.Text.PadRight(10, '0'));
                        txtIdLivro.Text = l.IdLivro + "";

                        // após incluir, clicamos no botão exibir para o dgv ser atualizado automaticamente
                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch
                {
                    MessageBox.Show("Código inválido!");
                }
            }

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text == "")
                MessageBox.Show("Id ausente!");
            else
            {
                Livro livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", "");
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.ExcluirLivro(livro);
                    MessageBox.Show("Exclusão feita com sucesso!");

                    // após excluir, clicamos no botão exibir para o dgv ser atualizado automaticamente
                    btnExibir.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtCodigoLivro.Text == "")
                MessageBox.Show("Preencha o Id para buscar por um Livro!");
            else
            {
                string codigo = txtCodigoLivro.Text;
                try
                {
                    Livro livro = new Livro(0, codigo, "", "");
                    try
                    {
                        LivroBLL bll = new LivroBLL(banco, usuario, senha);
                        livro = bll.ListarLivroPorCodigo(codigo);
                        if (livro != null)
                        {
                            txtIdLivro.Text = livro.IdLivro + "";
                            txtCodigoLivro.Text = livro.CodigoLivro;
                            txtTituloLivro.Text = livro.TituloLivro;
                            txtAutorLivro.Text = livro.AutorLivro;
                        }
                        else
                        {
                            MessageBox.Show("Erro! Livro inexistente!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                    txtIdLivro.ReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Código inválido!");
                }
            }
        }
        //botao para a ajuda de usuarios, caso o uso do programa fique confuso
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para exibir as estatisticas na aba Lista pressione o botão exibir");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text == "")
                MessageBox.Show("Id ausente!");
            else
            {
                try
                {
                    Livro livro = new Livro(int.Parse(txtIdLivro.Text),
                                                txtCodigoLivro.Text,
                                                txtTituloLivro.Text,
                                                txtAutorLivro.Text);
                    try
                    {
                        LivroBLL bll = new LivroBLL(banco, usuario, senha);
                        bll.AlterarLivro(livro);
                        MessageBox.Show("Alteração feita com sucesso!");

                        // após alterar, clicamos no botão exibir para o dgv ser atualizado automaticamente
                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch
                {
                    MessageBox.Show("Informações inválidas!");
                }
            }
        }
        public FrmLivro()
        {
            InitializeComponent();
        }
    }
}
