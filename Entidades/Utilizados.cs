using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Utilizados
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        
        [ForeignKey("ProductoId")] 
        public Productos producto { get; set; } = new Productos();

        public Utilizados()
        {
            Cantidad = 0;
            Descripcion = null;
        }

        public Utilizados(int cantidad, string descripcion, int id)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
            ProductoId = id;
        }
    }
}