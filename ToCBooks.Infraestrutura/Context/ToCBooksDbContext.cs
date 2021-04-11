using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToCBooks.Domain.Entidades;

namespace ToCBooks.Infraestrutura.Context
{
    public class ToCBooksDbContext : DbContext
    {
        public ToCBooksDbContext(DbContextOptions<ToCBooksDbContext> options) : base(options) { }

        public DbSet<Livros> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LivrosCategorias> LivrosCategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
