﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LivroDAL
    {
        string _conexaoSQLServer = "";
        SqlConnection _conexao = null;

        public LivroDAL(string banco, string usuario, string senha)
        {
            _conexaoSQLServer =
                $"Data Source = regulus.cotuca.unicamp.br; Initial Catalog={banco};" +
                $"User id = {usuario}; Password={senha}";
        }

        // retorna uma lista de Livros, ou seja, um objeto da classe List<Livro> com os
        // livros selecionados;
        public List<Livro> SelectListLivros()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexaoSQLServer))
                {
                    using (SqlCommand command =
                    new SqlCommand("SELECT * FROM bibLivro", conn))
                    {
                        conn.Open();
                        List<Livro> listaLivros = new List<Livro>();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Livro livro = new Livro(
                                (int)dr["idLivro"],
                                     dr["codigoLivro"] + "",
                                     dr["tituloLivro"] + "",
                                     dr["autorLivro"] + ""
                                );
                                listaLivros.Add(livro);
                            }
                        }
                        return listaLivros;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }
        public DataTable SelectLivros()
        {
            try
            {
                string sql = "SELECT idLivro,codigoLivro,tituloLivro,autorLivro FROM bibLivro";
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
        public Livro SelectLivroById(int idDesejado)
        {
            try
            {
                string sql = "SELECT idLivro, codigoLivro, tituloLivro, autorLivro " +
                             " FROM bibLivro WHERE idLivro = @id";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;
                if (dr.Read()) //se houve um registtro retornado, ja o le         
                {
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                                      dr["codigoLivro"].ToString(),
                                                      dr["tituloLivro"].ToString(),
                                                      dr["autorLivro"].ToString());
                }
                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Livro SelectLivroByCodigo(string codigoDesejado)
        {
            try
            {
                string sql = "SELECT idLivro, codigoLivro, tituloLivro, autorLivro " +
                             " FROM bibLivro" +
                             " WHERE codigoLivro = @codigo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@codigo", codigoDesejado);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;
                if (dr.Read())
                {
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                                      dr["codigoLivro"].ToString(),
                                                      dr["tituloLivro"].ToString(),
                                                      dr["autorLIvro"].ToString());
                }
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertLivro(Livro qualLivro)
        {
            try
            {
                string sql = "INSERT INTO bibLivro " +
                             " (codigoLivro, tituloLivro, autorLivro) " +
                             " VALUES (@codigo,@titulo, @autor) ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);
                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);
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
        public void DeleteLivro(Livro qualLivro)
        {
            try
            {
                string sql = "DELETE FROM bibLivro WHERE idLIvro = @idLivro ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
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
        public void UpdateLivro(Livro qualLivro)
        {
            try
            {
                string sql = "UPDATE bibLivro " +
                             " SET tituloLivro= @titulo ," +
                             " codigoLivro=@codigo," +
                             " autorLivro=@autor " +
                             " WHERE idLivro = @idLivro ";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);

                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);
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