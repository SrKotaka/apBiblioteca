using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class LeitorBLL
    {
        DAL.LeitorDAL dal = null;
        public string banco, usuario, senha;

        public LeitorBLL(string banco, string usuario, string senha)
        {
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public DataTable SelecionarLeitores()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                tb = dal.SelectLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }

        public void IncluirLeitor(Leitor leitor)
        {
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                dal.InsertLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AlterarLeitor(Leitor leitor)
        {
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                dal.UpdateLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLeitor(Leitor leitor)
        {
            dal = new LeitorDAL(banco, usuario, senha);
            EmprestimoDAL emprestimoDal = new EmprestimoDAL(banco, usuario, senha);
            DataTable lista = emprestimoDal.SelectEmprestimo();

            // percorremos os empréstimos e, caso aquele leitor ainda esteja com livros emprestados, ou seja, 
            // se a dataDevolucaoReal for nula, é lançada uma exceção, pois ainda não pode-se excluir o leitor
            for (int i = 0; i < lista.Rows.Count; i++)
            {
                if ((int)lista.Rows[i][2] == leitor.IdLeitor && lista.Rows[i][5] == DBNull.Value)
                    throw new Exception("Erro! O Leitor ainda tem livros emprestados!");
            }

            dal.DeleteLeitor(leitor);
        }

        public List<Leitor> ListarLeitores()
        {
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                return dal.SelectListLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor ListarLeitorPorId(int id)
        {
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                return dal.SelectLeitorById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarLeitoresPorNome(string nome)
        {
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                return dal.ListarLeitoresPorNome(nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
