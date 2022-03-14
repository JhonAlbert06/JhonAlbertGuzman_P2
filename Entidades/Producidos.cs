using System.ComponentModel.DataAnnotations;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Producidos
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        
        public Producidos()
        {
            Cantidad = 0;
            Descripcion = null;
        }

        public Producidos(int cantidad, string descripcion)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}