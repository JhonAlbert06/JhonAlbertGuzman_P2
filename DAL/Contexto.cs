using Microsoft.EntityFrameworkCore;
using JhonAlbertGuzman_P2.Entidades;

namespace JhonAlbertGuzman_P2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosEmpaque> ProductosEmpaque { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
    }
}