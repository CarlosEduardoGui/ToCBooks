using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            //A classe que possui as filhas que configura o mapeamento

            //builder.HasKey(c => c.Id);

            //builder.HasMany(c => c.EnderecoCobranca)
            //    .WithOne(eC => eC.Cliente)
            //    .HasForeignKey(eC => eC.Id);


            //builder.HasMany(c => c.EnderecoEntrega)
            //    .WithOne(eE => eE.Cliente)
            //    .HasForeignKey(eE => eE.Id);


            //builder.HasMany(c => c.CartaoCredito)
            //    .WithOne(cC => cC.Cliente)
            //    .HasForeignKey(cC => cC.Id);

            builder.HasOne(c => c.Login)
                .WithOne(l => l.Cliente)
                .HasForeignKey<LoginModel>(l => l.ClienteId);
        }
    }
}
