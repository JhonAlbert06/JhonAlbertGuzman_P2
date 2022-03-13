using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Producido
    {
        [Key]
        public int Id { get; set; }
        public int ProductoEmpaqueId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        public Producido()
        {
            Id = 0;
            ProductoEmpaqueId = 0;
            Cantidad = 0;
            Descripcion = null;
        }

        public Producido(int cantidad, string descripcion)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}