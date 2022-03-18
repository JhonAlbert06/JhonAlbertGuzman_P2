using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Productos
    {
        [Key]

        [Range(0, int.MaxValue, ErrorMessage = "El ID debe estar en el rango de {1} y {2}.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage = "La Existencia no puede estar vacio...")]
        [Range(1, int.MaxValue, ErrorMessage = "La existencia debe estar en el rango de {1} y {2}.")]
        public double Existencia { get; set; }
        
        [Required(ErrorMessage = "El Costo no puede estar vacio...")]
        [Range(1, double.MaxValue, ErrorMessage = "El Costo debe estar en el rango de {1} y {2}.")]
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double ValorInventario { get; set; }
        public double Ganancia { get; set; }
        public DateTime? Fecha { get; set; }
        public double Peso { get; set ;}

        [ForeignKey("ProductoId")]
        public List<ProductosDetalle> Detalle { get; set; } = new List<ProductosDetalle> ();
    }
}