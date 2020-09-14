using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class LivrosMapping : IEntityTypeConfiguration<LivrosModel>
    {
        public void Configure(EntityTypeBuilder<LivrosModel> builder)
        {

        }
    }
}
