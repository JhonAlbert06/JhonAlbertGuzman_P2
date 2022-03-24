using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JhonAlbertGuzman_P2.DAL;
using JhonAlbertGuzman_P2.Entidades;

namespace JhonAlbertGuzman_P2.BLL
{
    public class ProductoEmpaqueBLL
    {
        public ProductoBLL productosBLL { get; set; }

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

        private bool Insertar(ProductosEmpaque empaque)
        {
            bool paso = false;

            try
            {

                _contexto.ProductosEmpaque.Add(empaque);

                foreach (var item in empaque.Utilizados)
                {
                    _contexto.Entry(item).State = EntityState.Added;
                    _contexto.Entry(item.producto).State = new EntityState();
                    _contexto.Entry(item.producto).State = EntityState.Modified;
                    item.producto.Existencia -= item.Cantidad;
                    RestaInvetarios(item.ProductoId);
                }

                var producido = _contexto.Productos.Find(empaque.EmpaqueId).Existencia += empaque.Cantidad;
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

                var anterior = _contexto.ProductosEmpaque
                    .Where(x => x.EmpaqueId == empaque.EmpaqueId)
                    .Include(x => x.Utilizados)
                    .ThenInclude(x => x.producto)
                    .AsNoTracking()
                    .SingleOrDefault();

                foreach (var item in anterior.Utilizados)
                {
                    item.producto.Existencia += item.Cantidad;
                }

                var producido = _contexto.Productos.Find(empaque.EmpaqueId).Existencia -= empaque.Cantidad;
                _contexto.Database.ExecuteSqlRaw($"Delete FROM Utilizados where EmpaqueId={empaque.EmpaqueId}");

                foreach (var item in empaque.Utilizados)
                {
                    _contexto.Entry(item).State = EntityState.Added;
                    _contexto.Entry(item.producto).State = EntityState.Modified;
                    item.producto.Existencia -= item.Cantidad;
                    RestaInvetarios(item.ProductoId);
                }
                
                var producido2 = _contexto.Productos.Find(empaque.EmpaqueId).Existencia += empaque.Cantidad;

                _contexto.Entry(empaque).State = EntityState.Modified;
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
                var empaque = _contexto.ProductosEmpaque.Find(Id);

                if (empaque != null)
                {
                    foreach (var item in empaque.Utilizados)
                    {
                        _contexto.Entry(item.producto).State = EntityState.Modified;
                        item.producto.Existencia += item.Cantidad;
                        SumaInventarios(item.ProductoId);
                    }
                    
                    var producido = _contexto.Productos.Find(empaque.EmpaqueId).Existencia -= empaque.Cantidad;
                    
                    _contexto.ProductosEmpaque.Remove(empaque);
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

        public void RestaInvetarios(int id)
        {
            var producto = productosBLL.Buscar(id);                    
            producto.Ganancia = ((producto.Precio - producto.Costo) * 100) / producto.Costo;
            producto.ValorInventario = producto.Existencia * producto.Costo;
            productosBLL.ModificarInventario(producto);
        }

        public void SumaInventarios(int id)
        {
            var producto = productosBLL.Buscar(id);                    
            producto.Ganancia = ((producto.Precio - producto.Costo) * 100) / producto.Costo;
            producto.ValorInventario = producto.Existencia * producto.Costo;
            productosBLL.ModificarInventario(producto);
        } 

    }
}