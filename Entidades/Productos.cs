using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public double Existencia { get; set; }
        public double Costo { get; set; }
        public double ValorInventario { get; set; }
        public double Ganancia { get; set; }
        public double Precio { get; set; } 
        public DateTime Fecha { get; set; }

        [ForeignKey("ProductoId")]
        public List<ProductosDetalle> Detalle { get; set; } = new List<ProductosDetalle> ();
    }
}