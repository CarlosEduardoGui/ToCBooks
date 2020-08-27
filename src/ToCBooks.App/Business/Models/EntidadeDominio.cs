using System;

namespace ToCBooks.App.Business.Models
{
    public abstract class EntidadeDominio
    {
        protected EntidadeDominio()
        {
            Id = Guid.NewGuid();
            StatusAtual = Status.Ativo;
        }
        public enum Status
        {
            Ativo = 0,
            Inativo = 1
        }

        public Guid Id { get; set; }
        private Status _status;
        public Status StatusAtual
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
