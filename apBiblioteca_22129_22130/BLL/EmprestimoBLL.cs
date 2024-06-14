using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class EmprestimoBLL
    {
        EmprestimoDAL dal = null;
        public string banco, usuario, senha;
        public EmprestimoBLL (string banco, string usuario, string senha)
        {
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public DataTable SelecionarEmprestimos ()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);
                tb = dal.SelectEmprestimo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }

        public void IncluirEmprestimo (Emprestimo e)
        {
            EmprestimoDAL dalEmprestimo = new EmprestimoDAL(banco, usuario, senha);
            DataTable listaEmprestimos = dalEmprestimo.SelectEmprestimo();

            try
            {
                int contador = 0;
                for (int i = 0; i < listaEmprestimos.Rows.Count; i++)
                {
                    // se aquele empréstimo conter um livro que já ainda não foi devolvido, é lançada uma exceção, pois é
                    // impossível para uma pessoa emprestar um livro que não esteja na biblioteca
                    if (e.IdLivro == (int)listaEmprestimos.Rows[i][1] && listaEmprestimos.Rows[i][5] == DBNull.Value)
                        throw new Exception("Erro! O Livro já está emprestado!");

                    // caso seja feito um empréstimo com o mesmo leitor N vezes, esse N número é guardado na variável contador
                    if (e.IdLeitor == (int)listaEmprestimos.Rows[i][2] && listaEmprestimos.Rows[i][5] == DBNull.Value)
                        contador++;

                    // caso o contador seja cinco, ou seja, aquele mesmo leitor já possui 5 livros emprestados, é lançada uma 
                    // exceção, pois o mesmo atingiu o limite estipulado
                    if (contador == 5)
                        throw new Exception("Erro! O Usuário já possui atingiu o limite de cinco livros emprestados!");
                }

                dalEmprestimo.InsertEmprestimo(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarEmprestimo(Emprestimo e, bool comDevolucaoReal)
        {
            EmprestimoDAL dalEmprestimo = new EmprestimoDAL(banco, usuario, senha);

            try
            {
                dalEmprestimo.UpdateEmprestimo(e, comDevolucaoReal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEmprestimo(Emprestimo e)
        {
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);

                dal.DeleteEmprestimo(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> ListarEmprestimos()
        {
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);
                return dal.SelectListEmprestimo(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Emprestimo ListarEmprestimoPorId(int id, bool comDevolucaoReal)
        {
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);
                return dal.SelectEmprestimoById(id, comDevolucaoReal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarEmprestimoPorIdLivro(int idLivro)
        {
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);
                return dal.SelectEmprestimoPorLivros(idLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListaEmprestimoPorIdLeitor(int idLeitor)
        {
            try
            {
                dal = new EmprestimoDAL(banco, usuario, senha);
                return dal.SelectEmprestimosPorLeitores(idLeitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
