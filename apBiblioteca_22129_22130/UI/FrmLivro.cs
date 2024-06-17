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
            dgvLivro.AutoGenerateColumns = true;
            dgvLivro.BindingContext = new BindingContext();

            dgvLivro.AutoResizeColumns();
        }

        // botão para incluir um novo livro
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodigoLivro.Text == "" || txtTituloLivro.Text == "" || txtAutorLivro.Text == "")
                MessageBox.Show("Sem informações!");
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
                        LivroBLL bll = new LivroBLL(banco, usuario, senha);   // nome do banco, o usuario e a senha
                        bll.IncluirLivro(livro);  // inclui um novo livro
                        MessageBox.Show("Inclusão feita com sucesso!");  // a inclusao deu certo

                        Livro l = bll.ListarLivroPorCodigo(txtCodigoLivro.Text.PadRight(10, '0'));
                        txtIdLivro.Text = l.IdLivro + "";

                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);  // caso de erro, entra no catch
                    }
                }
                catch
                {
                    MessageBox.Show("Código inválido!"); // caso tudo de erro, entra no catch maior
                }
            }

        }

        // botão para excluir um livro
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text == "")
                MessageBox.Show("Id ausente!");  // o id do livro não foi preenchido
            else
            {
                Livro livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", "");   // converte para inteiro
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);   // nome do banco, o usuario e a senha
                    bll.ExcluirLivro(livro);  // exclui o livro
                    MessageBox.Show("Exclusão feita com sucesso!");  // a exclusao deu certo

                    btnExibir.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);  // caso de erro, entra no catch
                }
            }
        }

        // botão para procurar um livro
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtCodigoLivro.Text == "")
                MessageBox.Show("Preencha o Id para buscar por um Livro!");  // é necessário preencher o id do livro
            else
            {
                string codigo = txtCodigoLivro.Text;
                try
                {
                    Livro livro = new Livro(0, codigo, "", "");
                    try
                    {
                        LivroBLL bll = new LivroBLL(banco, usuario, senha);   // nome do banco, o usuario e a senha
                        livro = bll.ListarLivroPorCodigo(codigo);
                        if (livro != null)  // se for nulo (null)
                        {
                            txtIdLivro.Text = livro.IdLivro + "";
                            txtCodigoLivro.Text = livro.CodigoLivro;
                            txtTituloLivro.Text = livro.TituloLivro;
                            txtAutorLivro.Text = livro.AutorLivro;
                        }
                        else
                        {
                            MessageBox.Show("Erro! O Livro não existe nod dados do banco de dados!");  // o livro não existe
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);  // erro
                    }
                    txtIdLivro.ReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Código inválido!");  // o código informado para o livro é inválido
                }
            }
        }

        // botão para solicitar ajuda
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para exibir as estatisticas na aba Lista pressione o botão exibir");  // mensagem de ajuda
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // botão para alterar um livro
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text == "")  // se o id for vazio
                MessageBox.Show("Id ausente!"); // mensagem de erro, pois o id está vazio e isso é permitido
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
                        bll.AlterarLivro(livro);  // alterar os dados de um livro
                        MessageBox.Show("Alteração feita com sucesso!");  // a alteração foi feita com sucesso

                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch
                {
                    MessageBox.Show("Informações inválidas!");  // as informações são inválidas
                }
            }
        }
        public FrmLivro()
        {
            InitializeComponent();
        }
    }
}
