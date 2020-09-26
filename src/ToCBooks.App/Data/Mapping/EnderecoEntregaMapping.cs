using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class EnderecoEntregaMapping : IEntityTypeConfiguration<EnderecoEntregaModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntregaModel> builder)
        {
            builder.HasOne(cC => cC.Cliente)
                .WithMany(c => c.EnderecoEntrega)
                .HasForeignKey(cC => cC.ClienteId);
        }
    }
}
