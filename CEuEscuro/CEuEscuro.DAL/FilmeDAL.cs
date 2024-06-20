using CEuEscuro.DAL;
using CEuEscuro.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEuEscuro.DAL
{
    public class FilmeDAL : Conexao
    {
        //CRUD
        //CREATE
        public void Create(FilmeDTO filme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT into Film (TituloFilm,ProdutoraFilm,UrlImgFilm,Classificacao_Id,Genero_Id) VALUES (@TituloFilm,@ProdutoraFilm,@UrlImgFilm,@Classificacao_Id,@Genero_Id);", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //READ
        public List<FilmeDTO> GetFilms()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm, TituloFilm, ProdutoraFilm, UrlImgFilm, DescricaoGenero, DescricaoClassificacao FROM Film INNER JOIN Genero ON Genero_Id = IdGenero INNER JOIN Classificacao ON Classificacao_Id = IdClassificacao;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//Lista vazia
                while (dr.Read())
                {
                    FilmeDTO filme = new FilmeDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Genero_Id = dr["DescricaoGenero"].ToString();
                    filme.Classificacao_Id = dr["DescricaoClassificacao"].ToString();

                    Lista.Add(filme);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //UPDATE
        public void Update(FilmeDTO filme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Film SET TituloFilm = @TituloFilm, ProdutoraFilm=@ProdutoraFilm, UrlImgFilm=@UrlImgFilm,Classificacao_Id=@Classificacao_Id, Genero_Id = @Genero_Id where IdFilm =@IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", filme.IdFilm);
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //DELETE
        public void Delete(int IdFilm)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", IdFilm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //search by id
        public FilmeDTO Search(int filmeId)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", filmeId);
                FilmeDTO filme = new FilmeDTO(); //Objeto Vazio
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    filme = new FilmeDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();
                }
                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //search by name
        public FilmeDTO Search(string tituloFilm)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE TituloFilm = @TituloFilm;", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", tituloFilm);
                FilmeDTO filme = new FilmeDTO(); //Objeto Vazio
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    filme = new FilmeDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();
                }
                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //load DDLClassificao
        public List<ClassificacaoDTO> LoadDDLClassificacao()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();
                List<ClassificacaoDTO> Lista = new List<ClassificacaoDTO>();//Lista Vazia :3
                while (dr.Read())
                {
                    ClassificacaoDTO classificacao = new ClassificacaoDTO();
                    classificacao.IdClassificacao = Convert.ToInt32(dr["IdClassificacao"]);
                    classificacao.DescricaoClassificacao = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(classificacao);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //load DDLGenero
        public List<GeneroDTO> LoadDDLGenero()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();//Lista Vazia :3
                while (dr.Read())
                {
                    GeneroDTO genero = new GeneroDTO();
                    genero.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    genero.DescricaoGenero = dr["DescricaoGenero"].ToString();
                    Lista.Add(genero);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<FilmeDTO> Filter(string genero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm, TituloFilm, ProdutoraFilm, UrlImgFilm, DescricaoGenero, DescricaoClassificacao FROM Film INNER JOIN Genero ON Genero_Id = IdGenero INNER JOIN Classificacao ON Classificacao_Id = IdClassificacao WHERE DescricaoGenero = @DescricaoGenero;", conn);
                cmd.Parameters.AddWithValue("@DescricaoGenero", genero);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//Lista vazia
                while (dr.Read())
                {
                    FilmeDTO filme = new FilmeDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Genero_Id = dr["DescricaoGenero"].ToString();
                    filme.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(filme);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }



        }



    }
}
