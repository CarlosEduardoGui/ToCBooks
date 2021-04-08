using Microsoft.EntityFrameworkCore;
using ToCBooks.Domain.Entidades;

namespace ToCBooks.Infraestrutura.Context
{
    public class ToCBooksDbContext : DbContext
    {
        public ToCBooksDbContext(DbContextOptions<ToCBooksDbContext> options) : base(options) { }

        public DbSet<Livros> Livros { get; set; }
    }
}
