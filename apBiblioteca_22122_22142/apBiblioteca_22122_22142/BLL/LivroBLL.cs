using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class LivroBLL
    {
        LivroDAL dal = null;
        public string banco, usuario, senha;

        public LivroBLL(string banco, string usuario, string senha)
        {
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public DataTable SelecionarLivros()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                tb = dal.SelectLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }

        public void IncluirLivro(Livro livro)
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                dal.InsertLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLivro(Livro livro)
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                dal.UpdateLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(Livro livro)
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                EmprestimoDAL emprestimoDal = new EmprestimoDAL(banco, usuario, senha);
                DataTable lista = emprestimoDal.SelectEmprestimo();

                // percorremos os empréstimos e, se aquele livro ainda estiver emprestado (o dataDevolucaoReal for nulo),
                // é lançada uma exceção, pois não faria sentido deletar o livro
                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    if ((int)lista.Rows[i][1] == livro.IdLivro && lista.Rows[i][5] == DBNull.Value)
                        throw new Exception("Erro! O Livro ainda está emprestado!");
                }

                dal.DeleteLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Livro> ListarLivros()
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                    return dal.SelectListLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro ListarLivroPorId(int id)
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                return dal.SelectLivroById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro ListarLivroPorCodigo(string codigo)
        {
            try
            {
                dal = new LivroDAL(banco, usuario, senha);
                return dal.SelectLivroByCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

