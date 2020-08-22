using System;

namespace ToCBooks.App.Business.Models
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
