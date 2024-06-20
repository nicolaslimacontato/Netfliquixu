using CEuEscuro.DAL;
using CEuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEuEscuro.BLL
{
    public class FilmeBLL
    {
        FilmeDAL objBLL = new FilmeDAL();
        //CRUD
        //Creat
        public void CreateFilm(FilmeDTO filme)
        {
            objBLL.Create(filme);
        }

        //Read
        public List<FilmeDTO> GetFilmAll()
        {
            return objBLL.GetFilms();
        }

        //Update
        public void UpdateFilm(FilmeDTO filme)
        {
            objBLL.Update(filme);
        }

        //Delete
        public void DeleteFilm(int filmeID)
        {
            objBLL.Delete(filmeID);
        }
        //Search by id
        public FilmeDTO GetById(int filmeId)
        {
            return objBLL.Search(filmeId);
        }

        //Search by Name
        public FilmeDTO GetByName(string filmeNome)
        {
            return objBLL.Search(filmeNome);
        }

        //Dropdown List
        public List<ClassificacaoDTO> LoadDDLClassificacao()
        {
            return objBLL.LoadDDLClassificacao();
        }
        public List<GeneroDTO> LoadDDLGenero()
        {
            return objBLL.LoadDDLGenero();
        }
        //Search by Name
        
        // Filter
        public List<FilmeDTO> FilterFilm(string genero)
        {
            return objBLL.Filter(genero);
        }

    }
}
