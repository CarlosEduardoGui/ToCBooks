using Microsoft.EntityFrameworkCore;

namespace ToCBooks.Data.Context
{
    public class ToCBooksContext : DbContext
    {
        public ToCBooksContext(DbContextOptions options) : base(options) { }
    }
}
