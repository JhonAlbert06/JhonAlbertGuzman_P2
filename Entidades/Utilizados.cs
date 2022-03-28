using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Utilizados
    {
        [Key]
        public int Id { get; set; }
        public int UtilizadoId { get; set; }
        
        [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe estar en el rango de {1} y {2}.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Descripcion { get; set; }
        
        [ForeignKey("ProductoId")] 
        public Productos producto { get; set; } = new Productos();
    }
}