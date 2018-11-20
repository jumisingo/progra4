﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.DAL;

namespace Backend.DAL
{
    public interface IUsuariosDAL : IDisposable
    {
        void Add(Usuarios Usuario);
        void Delete(string idUsuario);
        void Update(Usuarios Usuario);
        Usuarios GetUsuario(string idUsuario);
        List<Usuarios> GetUsuarios();
    }
}