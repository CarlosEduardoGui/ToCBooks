using System;
using ToCBooks.Domain.Enum;

namespace ToCBooks.Domain.Entidades
{
    public abstract class EntidadeDominio
    {
        protected EntidadeDominio()
        {
            StatusAtual = ETipoStatus.Ativo;
            DataCadastro = DateTime.Now;
        }

        public long Id { get; private set; }

        public ETipoStatus StatusAtual { get; private set; }

        public string Justificativa { get; private set; }

        public DateTime DataCadastro { get; private set; }


        public void AplicarJustificativa(string pJustificativa)
        {
            if (string.IsNullOrEmpty(pJustificativa))
                Justificativa = pJustificativa;
        }

        public void StatusInativo() => StatusAtual = ETipoStatus.Inativo;

    }
}
