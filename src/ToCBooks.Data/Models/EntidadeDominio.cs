using System;

namespace ToCBooks.Data.Models
{
    public abstract class EntidadeDominio
    {
        protected EntidadeDominio()
        {
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }
    }
}
