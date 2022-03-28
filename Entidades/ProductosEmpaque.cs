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

        [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe estar en el rango de {1} y {2}.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el Concepto")]
        public string Concepto { get; set; }

        [ForeignKey("EmpaqueId")]
        public List<Utilizados> Utilizados { get; set; } = new List<Utilizados>();
    }
}