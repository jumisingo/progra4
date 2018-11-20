using System;
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

    public void Delete(string idUsuario)
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
        return result;
    }

    public Usuarios GetUsuario(string idUsuario)
    {
        Usuarios result;
        using (context = new BDContext())
        {
            result = (from c in context.Usuarios
                      where c.idUsuario == idUsuario
                      select c).First();
        }
        return result;
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
}

