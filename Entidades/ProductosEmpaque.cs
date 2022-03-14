using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class ProductosEmpaque
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El ID debe estar en el rango de {1} y {2}.")]
        public int ProductoId { get; set; }
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "La cantidad no puede estar vacia...")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe estar en el rango de {1} y {2}.")]
        public int CantidadUtilizados { get; set; }

        [ForeignKey("ProductoId")]
        public List<Utilizado> Producidos { get; set; } = new List<Utilizado>();

    }
}