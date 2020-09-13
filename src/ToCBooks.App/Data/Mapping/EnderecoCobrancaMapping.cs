using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class EnderecoCobrancaMapping : IEntityTypeConfiguration<EnderecoCobrancaModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoCobrancaModel> builder)
        {
            builder.HasOne(cC => cC.Cliente)
                .WithMany(c => c.EnderecoCobranca)
                .HasForeignKey(cC => cC.ClienteId);
        }
    }
}
