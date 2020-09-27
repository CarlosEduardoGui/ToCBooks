using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class EstoqueMapping : IEntityTypeConfiguration<ItemEstoque>
    {
        public void Configure(EntityTypeBuilder<ItemEstoque> builder)
        {
        }
    }
}
