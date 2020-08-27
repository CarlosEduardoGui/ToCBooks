using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Context
{
    public class ToCBooksContext : DbContext
    {
        public DbSet<LivrosModel> Livro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FOC45IJ\SQLEXPRESS2017;Database=ToCBooks;User Id=sa; Password=syslg;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(y => y.ClrType == typeof(string))))
                propriedade.Relational().ColumnType = "varchar(250)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToCBooksContext).Assembly);

            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys()))
                relacionamento.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
