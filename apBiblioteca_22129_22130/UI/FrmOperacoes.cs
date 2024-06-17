using DTO;
using BLL;
using System;
using System.Windows.Forms;

namespace apBiblioteca_22129_22130.UI
{
    public partial class FrmOperacoes : Form
    {
        public string banco, usuario, senha;

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clCheck.Index && e.RowIndex != -1)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[0];


                txtIdEmprestimo.Text = dgvLista.Rows[e.RowIndex].Cells[1].Value + "";
                txtIdLeitor.Text = dgvLista.Rows[e.RowIndex].Cells[3].Value + "";
                txtIdLivro.Text = dgvLista.Rows[e.RowIndex].Cells[2].Value + "";
                dtDataEmprestimo.Text = dgvLista.Rows[e.RowIndex].Cells[4].Value + "";
                dtDevolucaoPrevista.Text = dgvLista.Rows[e.RowIndex].Cells[5].Value + "";
            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para exibir as estatisticas na aba Lista pressione o botão exibir");
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
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

        

        private void btnExcluir_Click_1(object sender, EventArgs e)
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

        private void btnExibir_Click_1(object sender, EventArgs e)
        {
            EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
            dgvLista.DataSource = bll.SelecionarEmprestimos();


            dgvLista.AutoGenerateColumns = true;
            dgvLista.BindingContext = new BindingContext();

            dgvLista.AutoResizeColumns();
        }

        private void btnProcurar_Click_1(object sender, EventArgs e)
        {
            if (txtIdLeitor.Text != "" && txtIdLivro.Text != "" && txtIdEmprestimo.Text != ""
                || txtIdLeitor.Text != "" && txtIdLivro.Text != ""
                || txtIdLeitor.Text != "" && txtIdEmprestimo.Text != ""
                || txtIdEmprestimo.Text != "" && txtIdLivro.Text != "")
                MessageBox.Show("Ambiguidade! Apenas buscar pela identificação do leitor, do livro ou do empréstimo!");

            else if (txtIdLeitor.Text == "" && txtIdLivro.Text == "" && txtIdEmprestimo.Text == "")
                MessageBox.Show("Preencha a identificação do leitor, do emprestimo ou do livro para buscar por um emprestimo!");

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
            else if (txtIdLeitor.Text != "")
            {

                tabControl1.SelectedTab = tabControl1.TabPages[2];
                try
                {
                    int idLeitor = Convert.ToInt32(txtIdLeitor.Text);
                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        dgvLista.DataSource = bll.ListaEmprestimoPorIdLeitor(idLeitor);

                       
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

        private void btnRegistrarDevolucao_Click_1(object sender, EventArgs e)
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
                        Emprestimo emprestimoAux = bll.ListarEmprestimoPorId(id, false);

                        Emprestimo emprestimo = null;
                        if (emprestimoAux != null)
                        {
                            emprestimo = new Emprestimo(emprestimoAux.IdEmprestimo,
                                                                  emprestimoAux.IdLivro,
                                                                  emprestimoAux.IdLeitor,
                                                                  emprestimoAux.DataEmprestimo,
                                                                  emprestimoAux.DataDevolucaoPrevista,
                                                                  dtDevolucaoReal.Value);
                            bll.AlterarEmprestimo(emprestimo, true);
                            MessageBox.Show("Devolução feita com sucesso!");

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

        private void btnNovo_Click_1(object sender, EventArgs e)
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
