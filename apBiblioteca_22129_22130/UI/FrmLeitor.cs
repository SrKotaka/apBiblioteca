using DTO;
using BLL;
using System;
using System.Windows.Forms;

namespace apBiblioteca_22129_22130.UI
{
    public partial class FrmLeitor : Form
    {
        public string banco, usuario, senha;
        public FrmLeitor()
        {
            InitializeComponent();
        }

        private void dgvLeitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clCheck.Index && e.RowIndex != -1)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[0];

                txtIdentificacao.Text = dgvLeitor.Rows[e.RowIndex].Cells[1].Value + "";
                txtNome.Text = dgvLeitor.Rows[e.RowIndex].Cells[2].Value + "";
                txtTelefone.Text = dgvLeitor.Rows[e.RowIndex].Cells[3].Value + "";
                txtEmail.Text = dgvLeitor.Rows[e.RowIndex].Cells[4].Value + "";
                txtEndereco.Text = dgvLeitor.Rows[e.RowIndex].Cells[5].Value + "";
            }
        }

        // botão para exibir os leitores
        private void btnExibir_Click_1(object sender, EventArgs e)
        {
            LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
            dgvLeitor.DataSource = bll.SelecionarLeitores();
            dgvLeitor.AutoGenerateColumns = true;
            dgvLeitor.BindingContext = new BindingContext();

            dgvLeitor.AutoResizeColumns();
        }

        // botão para excluir um leitor
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text == "")  // se o id do leitor não foi preenchido
                MessageBox.Show("Id ausente!");  // mensagem de erro
            else
            {
                try
                {
                    Leitor leitor = new Leitor(Convert.ToInt32(txtIdentificacao.Text), "", "", "", "");   // converte para inteiro
                    try
                    {
                        LeitorBLL bll = new LeitorBLL(banco, usuario, senha);   // nome do banco, o usuario e a senha
                        bll.ExcluirLeitor(leitor);  // exclui um leitor
                        MessageBox.Show("Exclusão feita com sucesso!");
                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // botão para alterar um leitor
        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text == "")  // se o id do leitor não foi preenchido
                MessageBox.Show("Id ausente!");
            else
            {
                try
                {
                    Leitor leitor = new Leitor(0, "", "", "", "");
                    leitor.IdLeitor = Convert.ToInt32(txtIdentificacao.Text);
                    leitor.NomeLeitor = txtNome.Text;
                    leitor.TelefoneLeitor = txtTelefone.Text;
                    leitor.EmailLeitor = txtEmail.Text;
                    leitor.EnderecoLeitor = txtEndereco.Text;

                    try
                    {
                        LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                        bll.AlterarLeitor(leitor);
                        MessageBox.Show("Alteração feita com sucesso!");
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

        private void dgvLeito_Enter(object sender, EventArgs e)
        {

        }

        // botão para incluir um leitor
        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text != "")
                MessageBox.Show("Erro! Não digitar id!");
            else
            {
                if (txtEmail.Text == "" || txtEndereco.Text == "" || txtNome.Text == "" || txtTelefone.Text == "")
                    MessageBox.Show("Informações ausentes!");
                else
                {
                    try
                    {
                        Leitor leitor = new Leitor(0, "", "", "", "");
                        leitor.NomeLeitor = txtNome.Text;
                        leitor.TelefoneLeitor = txtTelefone.Text;
                        leitor.EmailLeitor = txtEmail.Text;
                        leitor.EnderecoLeitor = txtEndereco.Text;
                        try
                        {
                            LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                            bll.IncluirLeitor(leitor);
                            MessageBox.Show("Inclusão feita com sucesso!");
                            btnExibir.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // botão para procurar um leitor
        private void btnProcurar_Click_1(object sender, EventArgs e)
        {
       
            if (txtIdentificacao.Text != "" && txtNome.Text != "")
                MessageBox.Show("Ambiguidade! Somente buscar por id ou nome!");

            else if (txtIdentificacao.Text == "" && txtNome.Text == "")
                MessageBox.Show("Preencha o Id ou um nome para buscar por um Leitor!");

            else if (txtIdentificacao.Text != "")
            {
                try
                {
                    string id = txtIdentificacao.Text;
                    Leitor leitor = new Leitor(0, id, "", "", "");
                    try
                    {
                        LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                        leitor = bll.ListarLeitorPorId(Convert.ToInt32(id));
                        if (leitor != null)
                        {
                            leitor.IdLeitor = Convert.ToInt32(txtIdentificacao.Text);
                            leitor.NomeLeitor = txtNome.Text;
                            leitor.TelefoneLeitor = txtTelefone.Text;
                            leitor.EmailLeitor = txtEmail.Text;
                            leitor.EnderecoLeitor = txtEndereco.Text;
                        }
                        else
                            MessageBox.Show("Erro! Id inválido!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (txtNome.Text != "")
            {
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                try
                {
                    string nome = txtNome.Text;
                    try
                    {
                        LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                        dgvLeitor.DataSource = bll.ListarLeitoresPorNome(nome);

                        dgvLeitor.AutoGenerateColumns = true;
                        dgvLeitor.BindingContext = new BindingContext();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
