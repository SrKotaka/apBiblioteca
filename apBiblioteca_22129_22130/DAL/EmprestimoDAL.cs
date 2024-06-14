using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    internal class EmprestimoDAL
    {
        string _conexaoSQLServer = "";
        SqlConnection _conexao = null;

        public EmprestimoDAL(string banco, string usuario, string senha)
        {
            _conexaoSQLServer =
                $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={banco};" +
                $"User id = {usuario}; Password={senha}";
        }

        // o parãmetro "comDevolucaoReal" foi adicionado para podermos selecionar os registros da tabela colocando ou não 
        // o campo dataDevolucaoReal, já que o mesmo pode ser nulo
        public List<Emprestimo> SelectListEmprestimo(bool comDevolucaoReal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexaoSQLServer))
                {
                    using (SqlCommand command =
                    new SqlCommand("SELECT * FROM bibEmprestimo", conn))
                    {
                        conn.Open();
                        List<Emprestimo> listaEmprestimo = new List<Emprestimo>();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Emprestimo emprestimo;
                                if (comDevolucaoReal) 
                                {
                                    emprestimo = new Emprestimo((int)dr["idEmprestimo"],
                                                                (int)dr["idLivro"],
                                                                (int)dr["idLeitor"],
                                                            (DateTime)dr["DataEmprestimo"],
                                                            (DateTime)dr["DataDevolucaoPrevista"],
                                                            (DateTime)dr["DataDevolucaoReal"]);
                                }
                                else
                                {
                                    emprestimo = new Emprestimo((int)dr["idEmprestimo"],
                                                               (int)dr["idLivro"],
                                                               (int)dr["idLeitor"],
                                                           (DateTime)dr["DataEmprestimo"],
                                                           (DateTime)dr["DataDevolucaoPrevista"]);
                                }

                                listaEmprestimo.Add(emprestimo);
                            }
                        }
                        return listaEmprestimo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }
        public DataTable SelectEmprestimo()
        {
            try
            {
                string sql = "SELECT * FROM bibEmprestimo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // o parãmetro "comDevolucaoReal" foi adicionado para podermos selecionar os campos da tabela colocando ou não 
        // o campo dataDevolucaoReal, já que o mesmo pode ser nulo
        public Emprestimo SelectEmprestimoById(int idDesejado, bool comDevolucaoReal)
        {
            try
            {
                string sql = "SELECT * FROM bibEmprestimo WHERE idEmprestimo = @id";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Emprestimo emprestimo = null;
                if (dr.Read()) //se houve um registtro retornado, ja o le         
                {
                    if (comDevolucaoReal)
                    {
                        emprestimo = new Emprestimo((int)dr["idEmprestimo"],
                                                (int)dr["idLivro"],
                                                (int)dr["idLeitor"],
                                            (DateTime)dr["DataEmprestimo"],
                                            (DateTime)dr["DataDevolucaoPrevista"],
                                            (DateTime)dr["DataDevolucaoReal"]);
                    }
                    else
                    {
                        emprestimo = new Emprestimo((int)dr["idEmprestimo"],
                                               (int)dr["idLivro"],
                                               (int)dr["idLeitor"],
                                           (DateTime)dr["DataEmprestimo"],
                                           (DateTime)dr["DataDevolucaoPrevista"]);
                    }
                }
                return emprestimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectEmprestimosPorLeitores(int idLeitor)
        {
            try
            {
                string sql = "SELECT * FROM bibEmprestimo WHERE idLeitor = @idLeitor";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", idLeitor);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }
        public DataTable SelectEmprestimoPorLivros(int idLivro)
        {
            try
            {
                string sql = "SELECT * FROM bibEmprestimo WHERE idLivro = @idLivro";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro );
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }
        
        // ao inserir um empréstimo, não adicionamos a dataDevolucaoReal, pois não faz sentido ao cadastrar um
        // empréstimo já inserirmos o campo
        public void InsertEmprestimo(Emprestimo qualEmprestimo)
        {
            try
            {
                string sql = "INSERT INTO bibEmprestimo " +
                             " (idLeitor, idLivro, dataEmprestimo, dataDevolucaoPrevista) " +
                             " VALUES (@leitor, @livro, @dataEmprestimo, @dataDevolucaoPrevista) ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@leitor", qualEmprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@livro", qualEmprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@dataEmprestimo", qualEmprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", qualEmprestimo.DataDevolucaoPrevista);

                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }
        public void DeleteEmprestimo(Emprestimo qualEmprestimo)
        {
            try
            {
                string sql = "DELETE FROM bibEmprestimo WHERE idEmprestimo = @idEmprestimo ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", qualEmprestimo.IdEmprestimo);
                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        // o parãmetro "comDevolucaoReal" foi adicionado para podermos atualizar a tabela colocando ou não 
        // o campo dataDevolucaoReal, já que o mesmo pode ser nulo
        public void UpdateEmprestimo(Emprestimo qualEmprestimo, bool comDevolucaoReal)
        {
            try
            {
                string sql;
                if (comDevolucaoReal)
                {
                    sql = "UPDATE bibEmprestimo " +
                                 " SET idLivro = @idLivro ," +
                                 " idLeitor = @idLeitor," +
                                 " dataEmprestimo = @dataEmprestimo, " +
                                 " dataDevolucaoPrevista = @dataDevolucaoPrevista, " +
                                 " dataDevolucaoReal = @dataDevolucaoReal " +
                                 " WHERE idEmprestimo = @idEmprestimo ";
                }
                else
                {
                    sql = "UPDATE bibEmprestimo " +
                                 " SET idLivro = @idLivro ," +
                                 " idLeitor = @idLeitor," +
                                 " dataEmprestimo = @dataEmprestimo, " +
                                 " dataDevolucaoPrevista = @dataDevolucaoPrevista " +
                                 " WHERE idEmprestimo = @idEmprestimo ";
                }
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualEmprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@idLeitor", qualEmprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@dataEmprestimo", qualEmprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", qualEmprestimo.DataDevolucaoPrevista);
                if (comDevolucaoReal)
                    cmd.Parameters.AddWithValue("@dataDevolucaoReal", qualEmprestimo.DataDevolucaoReal);
                cmd.Parameters.AddWithValue("@idEmprestimo", qualEmprestimo.IdEmprestimo);

                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
