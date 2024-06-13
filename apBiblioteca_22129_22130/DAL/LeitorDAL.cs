using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LeitorDAL
    {
        string _conexaoSQLServer = "";
        SqlConnection _conexao = null;

        public LeitorDAL(string banco, string usuario, string senha)
        {
            _conexaoSQLServer =
                $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={banco};" +
                $"User id = {usuario}; Password={senha}";
        }

        // retorna uma lista de Livros, ou seja, um objeto da classe List<Livro> com os
        // livros selecionados;
        public List<Leitor> SelectListLeitores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexaoSQLServer))
                {
                    using (SqlCommand command =
                    new SqlCommand("SELECT * FROM bibLeitor", conn))
                    {
                        conn.Open();
                        List<Leitor> listaLeitores = new List<Leitor>();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Leitor leitor = new Leitor(
                                (int)dr["idLeitor"],
                                     dr["nomeLeitor"] + "",
                                     dr["telefoneLeitor"] + "",
                                     dr["emailLeitor"] + "",
                                     dr["enderecoLeitor"] + ""
                                );
                                listaLeitores.Add(leitor);
                            }
                        }
                        return listaLeitores;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }
        public DataTable SelectLeitores()
        {
            try
            {
                string sql = "SELECT idLeitor,nomeLeitor,telefoneLeitor,emailLeitor,enderecoLeitor FROM bibLeitor";
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
        public Leitor SelectLeitorById(int idDesejado)
        {
            try
            {
                string sql = "SELECT idLeitor,nomeLeitor,telefoneLeitor,emailLeitor,enderecoLeitor FROM bibLeitor" +
                             " WHERE idLeitor = @id";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Leitor leitor = null;
                if (dr.Read()) //se houve um registtro retornado, ja o le         
                {
                    leitor = new Leitor((int)dr["idLeitor"],
                                            dr["nomeLeitor"].ToString(),
                                            dr["telefoneLeitor"].ToString(),
                                            dr["emailLeitor"].ToString(),
                                            dr["enderecoLeitor"].ToString());
                }
                return leitor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertLeitor(Leitor qualLeitor)
        {
            try
            {
                string sql = "INSERT INTO bibLeitor " +
                             " (nomeLeitor,telefoneLeitor,emailLeitor,enderecoLeitor) " +
                             " VALUES (@nomeLeitor,@telefoneLeitor,@emailLeitor,@enderecoLeitor) ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", qualLeitor.IdLeitor);
                cmd.Parameters.AddWithValue("@nomeLeitor", qualLeitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefoneLeitor", qualLeitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@emailLeitor", qualLeitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@enderecoLeitor", qualLeitor.EnderecoLeitor);
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
        public void DeleteLeitor(Leitor qualLeitor)
        {
            try
            {
                string sql = "DELETE FROM bibLeitor WHERE idLeitor = @idLeitor ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", qualLeitor.IdLeitor);
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
        public void UpdateLeitor(Leitor qualLeitor)
        {
            try
            {
                string sql = "UPDATE bibLeitor " +
                             " SET nomeLeitor=@nomeLeitor," +
                             " telefoneLeitor=@telefoneLeitor, " +
                             " emailLeitor=@emailLeitor, " +
                             " enderecoLeitor=@enderecoLeitor " +
                             " WHERE idLeitor = @idLeitor ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", qualLeitor.IdLeitor);
                cmd.Parameters.AddWithValue("@nomeLeitor", qualLeitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefoneLeitor", qualLeitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@emailLeitor", qualLeitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@enderecoLeitor", qualLeitor.EnderecoLeitor);
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

        public DataTable ListarLeitoresPorNome(string nome)
        {
            try
            {
                string sql = "SELECT * FROM bibLeitor WHERE nomeLeitor LIKE @nome";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
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
    }
}