using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
