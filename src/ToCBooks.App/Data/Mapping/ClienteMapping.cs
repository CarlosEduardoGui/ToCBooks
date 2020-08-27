using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {

        }
    }
}
