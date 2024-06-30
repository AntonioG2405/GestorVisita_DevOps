using GestorVisita.Data.Context;
using GestorVisita.Data.Entities;
using GestorVisita.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVisita.Data.Daos
{
    public class DaoUsuarios : IDaoUsuario
    {
        private readonly GV_Context context;

        public DaoUsuarios(GV_Context Context)
        {
            context = Context;
        }

        public void AddUsuario(Usuarios usuarios)
        {
            if (usuarios == null)
            {
                throw new ArgumentNullException(nameof(usuarios), "El objeto Usuarios no puede ser nulo.");
            }
            int nextId = context.Usuarios.Count() > 0 ? context.Usuarios.Max(v => v.Id) + 1 : 1;
            usuarios.Id = nextId;
            context.Usuarios.Add(usuarios);
            context.SaveChanges();
        }

        public void UpdateUsuario(Usuarios usuarios)
        {
            if (usuarios == null)
            {
                throw new ArgumentNullException(nameof(usuarios), "El objeto Usuario no puede ser nulo.");
            }

            context.Entry(usuarios).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUsuario(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("EL ID NO PUEDE SER 0.");
            }
            var usuarios = context.Usuarios.Find(id);
            if (usuarios != null)
            {
                context.Usuarios.Remove(usuarios);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("NO SE ENCONTRO El USUARIO CON EL ID QUE SE PASO.");
            }
        }

        public List<Usuarios> GetUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public Usuarios GetUsuariosById(int id)
        {
            return context.Usuarios.Find(id);
        }
    }
}
