using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class ProductosEmpaque
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "El ID debe estar en el rango de {1} y {2}.")]
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Concepto { get; set; }
        
        [Required(ErrorMessage = "El Costo no puede estar vacio...")]
        [Range(1, int.MaxValue, ErrorMessage = "El Costo debe estar en el rango de {1} y {2}.")]
        public int CantidadUtilizados { get; set; }

        [Required(ErrorMessage = "El Costo no puede estar vacio...")]
        [Range(1, int.MaxValue, ErrorMessage = "El Costo debe estar en el rango de {1} y {2}.")]
        public int CantidadProducido { get; set; }

        public ProductosEmpaque()
        {
            this.Id = 0;
            this.Fecha = null;
            this.Concepto = null;
            this.CantidadUtilizados = 0;
            this.CantidadProducido = 0;
        }

    }
}