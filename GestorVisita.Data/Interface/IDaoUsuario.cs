using GestorVisita.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVisita.Data.Interface
{
    public interface IDaoUsuario
    {
        void AddUsuario(Usuarios usuarios);
        void UpdateUsuario(Usuarios usuarios);
        void DeleteUsuario(int id);

        List<Usuarios> GetUsuarios();

        Usuarios GetUsuariosById(int id);
    }
}
