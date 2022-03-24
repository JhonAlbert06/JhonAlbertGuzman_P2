using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class ProductosEmpaque
    {       
     
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El ID debe estar en el rango de {1} y {2}.")]
        public int EmpaqueId { get; set; }
        public DateTime? Fecha { get; set; }

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Concepto { get; set; }

        [ForeignKey("EmpaqueId")]
        public List<Utilizados> Utilizados { get; set; } = new List<Utilizados>();
    }
}