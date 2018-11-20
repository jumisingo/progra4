using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.DAL;

namespace Backend.DAL
{
    public interface ICategoriaActivosDAL : IDisposable
    {
        void Add(CategoriaActivos CategoriaActivo);
        void Delete(int idCategoriaActivo);
        void Update(CategoriaActivos CategoriaActivo);
        CategoriaActivos GetCategoriaActivo(int idCategoriaActivo);
        List<CategoriaActivos> GetCategoriaActivos();
    }
}
