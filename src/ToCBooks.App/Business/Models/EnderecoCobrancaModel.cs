using System;
using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class EnderecoCobrancaModel : EntidadeDominio
    {
        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Bairro { get; set; }

        public int CEP { get; set; }

        public CidadeModel Cidade { get; set; }

        public ETipoLogradouro TipoLogradouro { get; set; }

        public ETipoResidencia TipoResidencia { get; set; }

        public string Observacao { get; set; }

        public bool Principal { get; set; }

        public Guid ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }


        public EnderecoCobrancaModel Clonar()
        {
            EnderecoCobrancaModel Clone = new EnderecoCobrancaModel
            {
                Id = this.Id,
                Numero = this.Numero,
                Nome = this.Nome,
                Bairro = this.Bairro,
                CEP = this.CEP,
                Cidade = this.Cidade,
                TipoLogradouro = this.TipoLogradouro,
                TipoResidencia = this.TipoResidencia,
                Observacao = this.Observacao,
                Principal = this.Principal,
                ClienteId = this.ClienteId,
                Cliente = this.Cliente
            };

            return Clone;
        }


    }
}
