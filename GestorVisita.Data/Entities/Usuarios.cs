﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVisita.Data.Entities
{
    public class Usuarios
    {
        public int Id {  get; set; }
        public string Nombre {  get; set; }
        public string Email { get; set; }
        public string Contraseña{ get; set; }
    }
}
