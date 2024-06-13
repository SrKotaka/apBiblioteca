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
    public partial class FrmOperacoes : Form
    {
        public string banco, usuario, senha;

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Emprestimo emprestimo = new Emprestimo(0, 0, 0, new DateTime(), new DateTime());
                emprestimo.IdLeitor = Convert.ToInt32(txtIdEmprestimo.Text);
                emprestimo.IdEmprestimo = Convert.ToInt32(txtIdEmprestimo.Text);
                emprestimo.IdLeitor = Convert.ToInt32(txtIdLeitor.Text);
                emprestimo.IdLivro = Convert.ToInt32(txtIdLivro.Text);
                emprestimo.DataEmprestimo = dtDataEmprestimo.Value;
                emprestimo.DataDevolucaoPrevista = dtDevolucaoPrevista.Value;

                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    bll.AlterarEmprestimo(emprestimo, false);
                    MessageBox.Show("Alteração feita com sucesso!");

                    // após alterar, clicamos no botão exibir para o dgv ser atualizado automaticamente
                    btnExibir.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdEmprestimo.Text == "")
                MessageBox.Show("Está faltando preencher id!");
            else
            {
                try
                {
                    Emprestimo emprestimo = new Emprestimo(Convert.ToInt32(txtIdEmprestimo.Text), 0, 0, new DateTime(), new DateTime());
                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        bll.ExcluirEmprestimo(emprestimo);
                        MessageBox.Show("Exclusão feita com sucesso!");

                        // após excluir, clicamos no botão exibir para o dgv ser atualizado automaticamente
                        btnExibir.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            // demos a opção ao usuário de buscar empréstimos tanto por idEmprestimo quando por idLeitor e idLivro

            // as verificações abaixo servem para, caso o usuário tente buscar por mais de um campo, seja exibida uma mensagem de erro
            if (txtIdLeitor.Text != "" && txtIdLivro.Text != "" && txtIdEmprestimo.Text != ""
                || txtIdLeitor.Text != "" && txtIdLivro.Text != ""
                || txtIdLeitor.Text != "" && txtIdEmprestimo.Text != ""
                || txtIdEmprestimo.Text != "" && txtIdLivro.Text != "")
                MessageBox.Show("Ambiguidade! Apenas buscar pela identificação do leitor, do livro ou do empréstimo!");

            else if (txtIdLeitor.Text == "" && txtIdLivro.Text == "" && txtIdEmprestimo.Text == "")
                MessageBox.Show("Preencha a identificação do leitor, do emprestimo ou do livro para buscar por um emprestimo!");

            // se o usuário quer buscar por idEmprestimo
            else if (txtIdEmprestimo.Text != "")
            {
                try
                {
                    string id = txtIdEmprestimo.Text;
                    Emprestimo emprestimo = new Emprestimo(Convert.ToInt32(id), 0, 0, new DateTime(), new DateTime());
                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        emprestimo = bll.ListarEmprestimoPorId(Convert.ToInt32(id), false);
                        if (emprestimo != null)
                        {
                            txtIdEmprestimo.Text = emprestimo.IdEmprestimo + "";
                            txtIdLeitor.Text = emprestimo.IdLeitor + "";
                            txtIdLivro.Text = emprestimo.IdLivro + "";
                            dtDataEmprestimo.Text = emprestimo.DataEmprestimo + "";
                            dtDevolucaoPrevista.Text = emprestimo.DataDevolucaoPrevista + "";
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
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            // se o usuário quer buscar por idLeitor
            else if (txtIdLeitor.Text != "")
            {
                // selecionamos a guia de lista, para que ele possa ver os empréstimos com o idLeitor igual ao digitado pelo mesmo
                tabControl1.SelectedTab = tabControl1.TabPages[2];
                try
                {
                    int idLeitor = Convert.ToInt32(txtIdLeitor.Text);
                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        dgvLista.DataSource = bll.ListaEmprestimoPorIdLeitor(idLeitor);

                        // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados
                        dgvLista.AutoGenerateColumns = true;
                        dgvLista.BindingContext = new BindingContext();
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
            // se o usuário quer buscar por idLivro
            else if (txtIdLivro.Text != "")
            {
                tabControl1.SelectedTab = tabControl1.TabPages[2];
                try
                {
                    int idLivro = Convert.ToInt32(txtIdLivro.Text);
                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        dgvLista.DataSource = bll.ListarEmprestimoPorIdLivro(idLivro);

                        // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados
                        dgvLista.AutoGenerateColumns = true;
                        dgvLista.BindingContext = new BindingContext();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
            dgvLista.DataSource = bll.SelecionarEmprestimos();

            // os comandos abaixo são usados para o dgv auto gerar as colunas com base nos campos da tabela no banco de dados

            dgvLista.AutoGenerateColumns = true;
            dgvLista.BindingContext = new BindingContext();

            dgvLista.AutoResizeColumns();
        }

        private void btnRegistrarDevolucao_Click(object sender, EventArgs e)
        {
            if (txtIdCadastro.Text == "")
                MessageBox.Show("Id ausente!");
            else
            {
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    int id = Convert.ToInt32(txtIdCadastro.Text);
                    try
                    {
                        // criamos um empréstimo auxiliar, sem a dataDevolucaoReal
                        Emprestimo emprestimoAux = bll.ListarEmprestimoPorId(id, false);

                        Emprestimo emprestimo = null;
                        if (emprestimoAux != null)
                        {
                            // criamos um empréstimo com as informações do auxilar + o valor do input
                            emprestimo = new Emprestimo(emprestimoAux.IdEmprestimo,
                                                                  emprestimoAux.IdLivro,
                                                                  emprestimoAux.IdLeitor,
                                                                  emprestimoAux.DataEmprestimo,
                                                                  emprestimoAux.DataDevolucaoPrevista,
                                                                  dtDevolucaoReal.Value);
                            bll.AlterarEmprestimo(emprestimo, true);
                            MessageBox.Show("Devolução feita com sucesso!");

                            // após registrar devolução, clicamos no botão exibir para o dgv ser atualizado automaticamente
                            btnExibir.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Id inválido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pode-se observar que, no dgvLista, há uma coluna "Selecionar", que é do tipo checkbox
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
                txtIdEmprestimo.Text = dgvLista.Rows[e.RowIndex].Cells[1].Value + "";
                txtIdLeitor.Text = dgvLista.Rows[e.RowIndex].Cells[3].Value + "";
                txtIdLivro.Text = dgvLista.Rows[e.RowIndex].Cells[2].Value + "";
                dtDataEmprestimo.Text = dgvLista.Rows[e.RowIndex].Cells[4].Value + "";
                dtDevolucaoPrevista.Text = dgvLista.Rows[e.RowIndex].Cells[5].Value + "";
            }
        }
        //botao para a ajuda de usuarios, caso o uso do programa fique confuso
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para exibir as estatisticas na aba Lista pressione o botão exibir");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtIdEmprestimo.Text != "")
                MessageBox.Show("Erro! IdEmprestimo não pode ser informado!");
            else
            {
                try
                {
                    Emprestimo emprestimo = new Emprestimo(0, 0, 0, new DateTime(), new DateTime());
                    emprestimo.IdLeitor = Convert.ToInt32(txtIdLeitor.Text);
                    emprestimo.IdLivro = Convert.ToInt32(txtIdLivro.Text);
                    emprestimo.DataEmprestimo = dtDataEmprestimo.Value;
                    emprestimo.DataDevolucaoPrevista = dtDevolucaoPrevista.Value;

                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        bll.IncluirEmprestimo(emprestimo);
                        MessageBox.Show("Inclusão feita com sucesso!");

                        // após inserir, clicamos no botão exibir para o dgv ser atualizado automaticamente
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

        public FrmOperacoes()
        {
            InitializeComponent();
        }
    }
}
