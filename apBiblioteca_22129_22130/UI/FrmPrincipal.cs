using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace apBiblioteca_22129_22130.UI
{
    public partial class Form1 : Form
    {
        UI.FrmLivro formLivros = null;
        UI.FrmLeitor formLeitores = null;
        UI.FrmOperacoes formOperacoes = null;
        UI.FrmRelatorios formRelatorios = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void simToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();  // fecha o programa, termina a sua execução
        }

        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");   // solicita ao usuario que informe o nome do banco, o usuario e a senha

            else
            {
                formLivros = new UI.FrmLivro();

                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);  // é criada uma instância de conexão com o banco de dados
                    conn.Open();  // a conexão ao banco de dados é aberta
                    formLivros.banco = txtBanco.Text;         // propriedade banco do formulário formLivros com o texto do controle txtBanco.
                    formLivros.usuario = txtUsuario.Text;    // propriedade banco do formulário formLivros com o texto do controle txtUsuario.
                    formLivros.senha = txtSenha.Text;       // propriedade banco do formulário formLivros com o texto do controle txtSenha.
                    formLivros.Show();  // o formulário 'formLivros' é exibido
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");   // caso de erro de conexão ao banco de dados, entra no catch
                }
            }
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");

            else
            {
                formOperacoes = new UI.FrmOperacoes();

                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);  // é criada uma instância de conexão com o banco de dados
                    conn.Open();
                    formOperacoes.banco = txtBanco.Text;
                    formOperacoes.usuario = txtUsuario.Text;
                    formOperacoes.senha = txtSenha.Text;
                    formOperacoes.Show();  // o formulário 'formLivros' é exibido
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");   // caso de erro de conexão ao banco de dados, entra no catch
                }
            }
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");

            else
            {
                formLeitores = new UI.FrmLeitor();
                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);
                    conn.Open();
                    formLeitores.banco = txtBanco.Text;
                    formLeitores.usuario = txtUsuario.Text;
                    formLeitores.senha = txtSenha.Text;
                    formLeitores.Show();
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");   // caso de erro de conexão ao banco de dados, entra no catch
                }
            }
        }

        private void emprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");

            else
            {
                formOperacoes = new UI.FrmOperacoes();

                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);
                    conn.Open();
                    formOperacoes.banco = txtBanco.Text;
                    formOperacoes.usuario = txtUsuario.Text;
                    formOperacoes.senha = txtSenha.Text;
                    formOperacoes.Show();
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");   // caso de erro de conexão ao banco de dados, entra no catch
                }
            }
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");
            else
            {
                formLivros = new UI.FrmLivro();
                formLivros.banco = txtBanco.Text;
                formLivros.usuario = txtUsuario.Text;
                formLivros.senha = txtSenha.Text;
                formLivros.Show();  // o formulário 'formLivros' é exibido
            }   
        }

        private void operaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperacoes formOperacoes = new FrmOperacoes();
            formOperacoes.Show();  // o formulário 'formLivros' é exibido
        }

        private void relatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelatorios formRelatorios = new FrmRelatorios();
            formRelatorios.Show();  // o formulário 'formLivros' é exibido
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();  // fecha o formulário
        }

        private void simToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();  // fecha o formulário
        }

        private void leitoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLeitor formLeitor = new FrmLeitor();
            formLeitor.Show();
        }
    }
}
