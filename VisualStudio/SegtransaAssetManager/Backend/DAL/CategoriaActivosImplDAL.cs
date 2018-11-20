using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.DAL;
using System.Data.Entity;

public class CategoriaActivosImplDAL : ICategoriaActivosDAL
{

    private BDContext context;

    public void Add(CategoriaActivos CategoriaActivo)
    {
        using (context = new BDContext())
        {
            context.CategoriaActivos.Add(CategoriaActivo);
            context.SaveChanges();
        }
    }

    public void Delete(int idCategoriaActivo)
    {
        CategoriaActivos CategoriaActivo = this.GetCategoriaActivo(idCategoriaActivo);
        using (context = new BDContext())
        {
            context.CategoriaActivos.Attach(CategoriaActivo);
            context.CategoriaActivos.Remove(CategoriaActivo);
            context.SaveChanges();
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public List<CategoriaActivos> GetCategoriaActivos()
    {
        List<CategoriaActivos> result;
        using (context = new BDContext())
        {
            result = (from c in context.CategoriaActivos
                      select c).ToList();
        }
        return result;
    }

    public CategoriaActivos GetCategoriaActivo(int idCategoriaActivo)
    {
        CategoriaActivos result;
        using (context = new BDContext())
        {
            result = (from c in context.CategoriaActivos
                      where c.idCategoriaActivos == idCategoriaActivo
                      select c).First();
        }
        return result;
    }

    public void Update(CategoriaActivos CategoriaActivo)
    {
        try
        {
            using (context = new BDContext())
            {
                context.Entry(CategoriaActivo).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        catch (Exception)
        {
            throw;
        }
    }
}

