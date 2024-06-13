using DTO;
using BLL;
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
    public partial class FrmLeitor : Form
    {
        public string banco, usuario, senha;
        public FrmLeitor()
        {
            InitializeComponent();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
            dgvLeitor.DataSource = bll.SelecionarLeitores();

            // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados
            dgvLeitor.AutoGenerateColumns = true;
            dgvLeitor.BindingContext = new BindingContext();

            dgvLeitor.AutoResizeColumns();
        }

        private void btnNovo_Click(object sender, EventArgs e)
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

                            // após registrar devolução, clicamos no botão exibir para o dgv ser atualizado automaticamente
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text == "")
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

                        // após registrar devolução, clicamos no botão exibir para o dgv ser atualizado automaticamente
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

        private void dgvLeitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pode-se observar que, no dgvLeitor, há uma coluna "Selecionar", que é do tipo checkbox
            /* implementamos essa coluna para, ao usuário exibir os registros ou procurar por certos ids que 
            podem ser repetidos, ele poder selecionar, ao clicar na mesma, qual registro deseja excluir ou alterar,
            voltando para a aba de empréstimo.
            */

            // caso o índice da coluna que o usuário clicou seja igual a coluna "Selecionar" e a linha que o usuário
            // clicou seja diferente do header (cabeçalho)
            if (e.ColumnIndex == clCheck.Index && e.RowIndex != -1)
            {
                // selecionamos a tabpage do empréstimo
                tabControl1.SelectedTab = tabControl1.TabPages[0];

                // mudamos nos textBoxes os valores com base no índice da linha que o usuário clicou
                txtIdentificacao.Text = dgvLeitor.Rows[e.RowIndex].Cells[1].Value + "";
                txtNome.Text = dgvLeitor.Rows[e.RowIndex].Cells[2].Value + "";
                txtTelefone.Text = dgvLeitor.Rows[e.RowIndex].Cells[3].Value + "";
                txtEmail.Text = dgvLeitor.Rows[e.RowIndex].Cells[4].Value + "";
                txtEndereco.Text = dgvLeitor.Rows[e.RowIndex].Cells[5].Value + "";
            }
        }
        //botao para a ajuda de usuarios, caso o uso do programa fique confuso
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MessageBox.Show(\"Para exibir as estatisticas na aba Lista pressione o botão exibir\");");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text == "")
                MessageBox.Show("Id ausente!");
            else
            {
                try
                {
                    Leitor leitor = new Leitor(Convert.ToInt32(txtIdentificacao.Text), "", "", "", "");
                    try
                    {
                        LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                        bll.ExcluirLeitor(leitor);
                        MessageBox.Show("Exclusão feita com sucesso!");

                        // após registrar devolução, clicamos no botão exibir para o dgv ser atualizado automaticamente
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
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            // demos a opção ao usuário de buscar leitores tanto por idLeitor quando por nomeLeitor

            // as verificações abaixo servem para, caso o usuário tente buscar por mais de um campo, seja exibida uma mensagem de erro
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

                        // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados
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
