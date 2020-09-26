using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Context
{
    public class ToCBooksContext : DbContext
    {
        public DbSet<LivrosModel> Livro { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Parametro> Categoria { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<EnderecoCobrancaModel> EnderecoCobranca { get; set; }
        public DbSet<EnderecoEntregaModel> EnderecoEntrega { get; set; }
        public DbSet<CartaoCreditoModel> CartaoCredito { get; set; }
        public DbSet<ItemEstoque> Estoque { get; set; }
        public DbSet<CupomModel> Cupom { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FOC45IJ\SQLEXPRESS2017;Database=ToCBooks;User Id=sa; Password=syslg;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-C46EB5G\SQLEXPRESS;Database=ToCBooks;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var propriedade in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(y => y.ClrType == typeof(string))))
                propriedade.Relational().ColumnType = "VARCHAR(MAX)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToCBooksContext).Assembly);

            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys()))
                relacionamento.DeleteBehavior = DeleteBehavior.ClientSetNull;

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
