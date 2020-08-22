using Microsoft.EntityFrameworkCore;
using ToCBooks.Business.Models;

namespace ToCBooks.Data.Context
{
    public class ToCBooksContext : DbContext
    {
        public DbSet<LivrosModel> Livro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FOC45IJ\\SQLEXPRESS2017;Database=ECommerceCore;User Id=sa; Password=syslg;MultipleActiveResultSets=true");
        }
    }
}
