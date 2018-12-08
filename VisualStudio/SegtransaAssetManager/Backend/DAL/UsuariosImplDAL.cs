﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.DAL;
using System.Data.Entity;

public class UsuariosImplDAL : IUsuariosDAL
{

    private BDContext context;

    public void Add(Usuarios Usuario)
    {
        using (context = new BDContext())
        {
            context.Usuarios.Add(Usuario);
            context.SaveChanges();
        }
    }

    public void Delete(int idUsuario)
    {
        Usuarios Usuario = this.GetUsuario(idUsuario);
        using (context = new BDContext())
        {
            context.Usuarios.Attach(Usuario);
            context.Usuarios.Remove(Usuario);
            context.SaveChanges();
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public List<Usuarios> GetUsuarios()
    {
        List<Usuarios> result;
        using (context = new BDContext())
        {
            result = (from c in context.Usuarios
                      select c).ToList();
        }
        IRolUsuariosDAL rolUsuariosDAL = new RolUsuariosImplDAL();
        foreach (Usuarios item in result)
        {
            item.Rol_Usuarios = rolUsuariosDAL.GetRol(item.idRol ?? default(int));
        }
        return result;
    }

    public Usuarios GetUsuario(int idUsuario)
    {
        try
        {
            Usuarios result;
            using (context = new BDContext())
            {
                result = (from c in context.Usuarios
                          where c.idUsuario == idUsuario
                          select c).First();
            }
            /*IRolUsuariosDAL rolUsuariosDAL = new RolUsuariosImplDAL();
            result.Rol_Usuarios = rolUsuariosDAL.GetRol(result.idRol ?? default(int));*/
            
            return result;
        }
        catch (Exception)
        {

            return null;
        }

    }

    public void Update(Usuarios Usuario)
    {
        try
        {
            using (context = new BDContext())
            {
                context.Entry(Usuario).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool isRealUser(int idUsuario)
    {
        bool real = false;
        if (this.GetUsuario(idUsuario) != null)
        {
            real = true;
        }
        return real;
    }
    public bool isValidPassword(string passUser, int idUsuario)
    {
        CryptoEngine cryptoEngine = new CryptoEngine();
        string passDecrypted = cryptoEngine.Decrypt(passUser);
        bool valid = false;
        if (this.GetUsuario(idUsuario).contrasena.Equals(passDecrypted))
        {
            valid = true;
        }
        return valid;
    }
}

