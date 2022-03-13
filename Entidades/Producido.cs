using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JhonAlbertGuzman_P2.Entidades
{
    public class Producido
    {
        public int Id { get; set; }
        public int ProductoEmpaqueId { get; set; }
        public int cantidad { get; set; }
    }
}