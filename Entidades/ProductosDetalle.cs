using System.ComponentModel.DataAnnotations;

namespace JhonAlbertGuzman_P2.Entidades
{
    
    public class ProductosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Presentacion { get; set; }

        [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe estar en el rango de {1} y {2}.")]
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public DateTime? Fecha { get; set; }

        public ProductosDetalle()
        {
            this.Id = 0;
            this.ProductoId = 0;
            this.Presentacion = null;
            this.Cantidad = 0;
            this.Precio = 0;
        }
        public ProductosDetalle(string descripcion, double cantidad, double precio)
        {
            this.Presentacion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
        public ProductosDetalle(string descripcion, double cantidad, double precio, DateTime fecha)
        {
            this.Presentacion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Fecha = fecha;
        }

    }

}