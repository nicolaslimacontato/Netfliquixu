using CEuEscuro.DAL;
using CEuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEuEscuro.BLL
{
    public class UsuarioBLL
    {
        //objeto para acesso geral aos recursos da DAL
        UsuarioDAL objBLL = new UsuarioDAL();
        //autenticar
        public UsuarioDTO AutenticarUsuario(string nome, string senha)
        {
            return objBLL.Autenticar(nome, senha);
        }

        //CRUD
        //Creat
        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.Create(usuario);
        }

        //Read
        public List<UsuarioDTO> GetUsersAll() 
        {
            return objBLL.GetUsers();
        }

        //Update
        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.Update(usuario);
        }

        //Delete
        public void DeleteUser(int usuarioId) 
        {
            objBLL.Delete(usuarioId);
        }

        //Search by id
        public UsuarioDTO GetById(int usuarioId)
        {
            return objBLL.Search(usuarioId);
        }

        //Search by Name
        public UsuarioDTO GetByName(string usuarioName)
        {
            return objBLL.Search(usuarioName);
        }

        //Dropdown List
        public List<TipoUsuarioDTO> LoadDDLTpUser() 
        {
            return objBLL.LoadDDL();
        }
    }
}
