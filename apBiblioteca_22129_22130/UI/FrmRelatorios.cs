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
    public partial class FrmRelatorios : Form
    {
        public string banco, usuario, senha;

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            try
            {
                EmprestimoBLL emprestimobll = new EmprestimoBLL(banco, usuario, senha);
                DataTable listaEmprestimo = emprestimobll.SelecionarEmprestimos();

                // setamos o número de linhas do dgv igual ao número de empréstimos
                dgvLivros.RowCount = listaEmprestimo.Rows.Count;

                for (int i = 0; i < listaEmprestimo.Rows.Count; i++)
                {
                    dgvLivros.Rows[i].Cells[0].Value = listaEmprestimo.Rows[i][0];

                    dgvLivros.Rows[i].Cells[1].Value = listaEmprestimo.Rows[i][1];

                    LivroBLL livrobll = new LivroBLL(banco, usuario, senha);
                    dgvLivros.Rows[i].Cells[2].Value = livrobll.ListarLivroPorId((int)listaEmprestimo.Rows[i][1]).TituloLivro;

                    dgvLivros.Rows[i].Cells[3].Value = listaEmprestimo.Rows[i][2];

                    LeitorBLL leitorbll = new LeitorBLL(banco, usuario, senha);
                    dgvLivros.Rows[i].Cells[4].Value = leitorbll.ListarLeitorPorId((int)listaEmprestimo.Rows[i][2]).NomeLeitor;

                    // caso o datatable tenha ou não sua coluna cinco (dataDevolucaoReal) nula, ou seja, 
                    // se aquele livro foi devolvido ou não
                    if (listaEmprestimo.Rows[i][5] == DBNull.Value)
                        dgvLivros.Rows[i].Cells[5].Value = "Não";
                    else
                        dgvLivros.Rows[i].Cells[5].Value = "Sim";

                    TimeSpan intervalo;
                    // caso a dataDevolucaoReal seja nula, calculamos o intervalo de atraso com base no dia de hoje
                    if (listaEmprestimo.Rows[i][5] == DBNull.Value)
                    {
                        intervalo = DateTime.Now.Subtract((DateTime)listaEmprestimo.Rows[i][4]);
                    }
                    // caso contrário, calculamos o intervalo com base na dataDevolucaoReal
                    else
                    {
                        DateTime dataDevolucaoReal = (DateTime)listaEmprestimo.Rows[i][5];
                        intervalo = dataDevolucaoReal.Subtract((DateTime)listaEmprestimo.Rows[i][4]);
                    }
                    // se os dias forem negativos (ou seja, o livro tiver sido entregue antes da data prevista), mudamos o valor para zero
                    if (intervalo.Days < 0)
                        dgvLivros.Rows[i].Cells[6].Value = 0;
                    else
                        dgvLivros.Rows[i].Cells[6].Value = intervalo.Days;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao gerar relatório dos Livros!");
            }

            try
            {
                LeitorBLL leitorbll = new LeitorBLL(banco, usuario, senha);
                DataTable listaLeitores = leitorbll.SelecionarLeitores();

                dgvLeitores.RowCount = listaLeitores.Rows.Count;

                for (int i = 0; i < listaLeitores.Rows.Count; i++)
                {
                    dgvLeitores.Rows[i].Cells[0].Value = listaLeitores.Rows[i][0];

                    dgvLeitores.Rows[i].Cells[1].Value = listaLeitores.Rows[i][1];

                    EmprestimoBLL emprestimobll = new EmprestimoBLL(banco, usuario, senha);
                    DataTable listaEmprestimo = emprestimobll.SelecionarEmprestimos();

                    int contadorLivrosEmprestados = 0;
                    int contadorLivrosAtrasados = 0;
                    for (int j = 0; j < listaEmprestimo.Rows.Count; j++)
                    {

                        // caso o empréstimo tenha o idLeitor atual e a sua dataDevolucaoReal seja nula (ele não foi devolvido ainda)
                        if ((int)listaLeitores.Rows[i][0] == (int)listaEmprestimo.Rows[j][2]
                            && listaEmprestimo.Rows[j][5] == DBNull.Value)
                        {
                            contadorLivrosEmprestados++;

                            // caso os dias do intervalo sejam maiores que 0 (ou seja, aquela pessoa possui livros atrasados)
                            TimeSpan intervalo = DateTime.Now.Subtract((DateTime)listaEmprestimo.Rows[j][4]);
                            if (intervalo.Days > 0)
                                contadorLivrosAtrasados++;
                        }
                    }

                    dgvLeitores.Rows[i].Cells[2].Value = contadorLivrosEmprestados;

                    dgvLeitores.Rows[i].Cells[3].Value = contadorLivrosAtrasados;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao gerar relatório dos leitores!");
            }
        }

        public FrmRelatorios()
        {
            InitializeComponent();
        }
    }
}
