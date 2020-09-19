using System;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public abstract class EntidadeDominio
    {
        protected EntidadeDominio()
        {
            Id = Guid.NewGuid();
            StatusAtual = ETipoStatus.Ativo;
            DataCadastro = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        
        public ETipoStatus StatusAtual { get; set; }
        
        public string Justificativa { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
