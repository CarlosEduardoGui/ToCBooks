using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class CartaoCreditoMapping : IEntityTypeConfiguration<CartaoCreditoModel>
    {
        public void Configure(EntityTypeBuilder<CartaoCreditoModel> builder)
        {
            builder.HasOne(cC => cC.Cliente)
                .WithMany(c => c.CartaoCredito)
                .HasForeignKey(cC => cC.ClienteId);
        }
    }
}
