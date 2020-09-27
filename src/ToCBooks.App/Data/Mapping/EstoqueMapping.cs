using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
