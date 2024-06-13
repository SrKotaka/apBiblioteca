using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Close();
        }

        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");

            else
            {
                formLivros = new UI.FrmLivro();

                // verificamos se o bd o usuário realmente existem e se a senha está correta ao tentarmos conetar com o bd
                // isso serve para o usuário não poder acessar outros forms caso não tenha digitado as informações corretamente
                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);
                    conn.Open();
                    formLivros.banco = txtBanco.Text;
                    formLivros.usuario = txtUsuario.Text;
                    formLivros.senha = txtSenha.Text;
                    formLivros.Show();
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");
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

                // verificamos se o bd o usuário realmente existem e se a senha está correta ao tentarmos conetar com o bd
                // isso serve para o usuário não poder acessar outros forms caso não tenha digitado as informações corretamente
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
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");
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

                // verificamos se o bd o usuário realmente existem e se a senha está correta ao tentarmos conetar com o bd
                // isso serve para o usuário não poder acessar outros forms caso não tenha digitado as informações corretamente
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
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");
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

                // verificamos se o bd o usuário realmente existem e se a senha está correta ao tentarmos conetar com o bd
                // isso serve para o usuário não poder acessar outros forms caso não tenha digitado as informações corretamente
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
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");
                }
            }
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexâo!");

            else
            {
                formRelatorios = new UI.FrmRelatorios();

                // verificamos se o bd o usuário realmente existem e se a senha está correta ao tentarmos conetar com o bd
                // isso serve para o usuário não poder acessar outros forms caso não tenha digitado as informações corretamente
                string _conexaoSQLServer = $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={txtBanco.Text};" +
                $"User id = {txtUsuario.Text}; Password={txtSenha.Text}";

                try
                {
                    SqlConnection conn = new SqlConnection(_conexaoSQLServer);
                    conn.Open();
                    formRelatorios.banco = txtBanco.Text;
                    formRelatorios.usuario = txtUsuario.Text;
                    formRelatorios.senha = txtSenha.Text;
                    formRelatorios.Show();
                }
                catch
                {
                    MessageBox.Show("Falha ao conectar com o Banco de Dados!");
                }
            }
        }
    }
}
