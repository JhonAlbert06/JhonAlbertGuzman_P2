using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JhonAlbertGuzman_P2.DAL;
using JhonAlbertGuzman_P2.Entidades;

namespace JhonAlbertGuzman_P2.BLL
{
    public class ProductoEmpaqueBLL
    {
       private Contexto _contexto;

       public ProductoEmpaqueBLL(Contexto contexto)
       {
           _contexto = contexto;
       } 

       public bool Guardar(ProductosEmpaque producto)
        {
            if (!Existe(producto.Concepto))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private bool Insertar(ProductosEmpaque producto)
        {
            bool paso = false;

            try
            {
                _contexto.ProductosEmpaque.Add(producto);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(ProductosEmpaque producto)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductosEmpaque WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.Producidos)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(producto).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int Id)
        {
            bool paso = false;

            try
            {
                var producto = _contexto.ProductosEmpaque.Find(Id);

                if (producto != null)
                {
                    _contexto.ProductosEmpaque.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public ProductosEmpaque Buscar(int Id)
        {
            ProductosEmpaque producto;

            try
            {
                producto = _contexto.ProductosEmpaque.Include(x => x.Producidos)
                .Where(p => p.ProductoId == Id)
                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return producto;
        }

        public bool Existe(string descripcion)
        {
            bool paso = false;

            try
            {
                paso = _contexto.ProductosEmpaque.Any(p => p.Concepto == descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool Existe(int Id)
        {
            bool paso = false;

            try
            {
                paso = _contexto.ProductosEmpaque.Any(p => p.ProductoId == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        
        public List<ProductosEmpaque> GetList(Expression<Func<ProductosEmpaque, bool>> critero)
        {
            List<ProductosEmpaque> lista = new List<ProductosEmpaque>();

            try
            {
                lista = _contexto.ProductosEmpaque.Where(critero).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }
}