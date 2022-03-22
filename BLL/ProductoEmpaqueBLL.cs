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

       public bool Guardar(ProductosEmpaque empaque)
        {
            if (!Existe(empaque.EmpaqueId))
            {
                
                return Insertar(empaque);
            }
            else
            {
                return Modificar(empaque);
            }
        }

        // editar este para que controle el inventario y la manera de agregar productos 
        // se deben recorrer
        private bool Insertar(ProductosEmpaque empaque)
        {
            bool paso = false;

            try
            {
                _contexto.ProductosEmpaque.Add(empaque).State = EntityState.Added;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(ProductosEmpaque empaque)
        {
            bool paso = false;

            try
            {
                _contexto.ProductosEmpaque.Update(empaque);
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
            ProductosEmpaque empaque;

            try
            {
                empaque = _contexto.ProductosEmpaque
                    .Include(u => u.Utilizados)
                    .Where(p => p.EmpaqueId == Id)
                    .AsNoTracking()
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return empaque;
        }

        public bool Existe(string descripcion)
        {
            bool paso = false;

            try
            {
                paso = _contexto.ProductosEmpaque
                    .AsNoTracking()
                    .Any(p => p.Concepto == descripcion);
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
                paso = _contexto.ProductosEmpaque
                    .AsNoTracking()
                    .Any(p => p.EmpaqueId == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        
        public List<ProductosEmpaque> GetListEmpaque(Expression<Func<ProductosEmpaque, bool>> critero)
        {
            List<ProductosEmpaque> lista = new List<ProductosEmpaque>();

            try
            {
                lista = _contexto.ProductosEmpaque
                    .Where(critero)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }


    }
}