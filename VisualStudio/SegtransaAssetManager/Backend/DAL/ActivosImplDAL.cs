using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.DAL;
using System.Data.Entity;

public class ActivosImplDAL : IActivosDAL
{

    private BDContext context;

    public void Add(Activos Activo)
    {
        using (context = new BDContext())
        {
            context.Activos.Add(Activo);
            context.SaveChanges();
        }
    }

    public void Delete(int idActivo)
    {
        Activos Activo = this.GetActivo(idActivo);
        using (context = new BDContext())
        {
            context.Activos.Attach(Activo);
            context.Activos.Remove(Activo);
            context.SaveChanges();
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public List<Activos> GetActivos()
    {
        List<Activos> result;
        using (context = new BDContext())
        {
            result = (from c in context.Activos
                      select c).ToList();
        }
        return result;
    }

    public Activos GetActivo(int idActivo)
    {
        Activos result;
        using (context = new BDContext())
        {
            result = (from c in context.Activos
                      where c.idActivo == idActivo
                      select c).First();
        }
        return result;
    }

    public void Update(Activos Activo)
    {
        try
        {
            using (context = new BDContext())
            {
                context.Entry(Activo).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        catch (Exception)
        {
            throw;
        }
    }
}

