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

        [ForeignKey("ProductoId")]
        public List<Utilizados> Utilizados { get; set; } = new List<Utilizados>();
        
        [ForeignKey("ProductoId")]
        public List<Producidos> Producidos { get; set; } = new List<Producidos>();
    }
}