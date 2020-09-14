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
            EnderecoCobrancaModel Clone = new EnderecoCobrancaModel();
            Clone.Id = this.Id;
            Clone.Numero = this.Numero;
            Clone.Nome = this.Nome;
            Clone.Bairro = this.Bairro;
            Clone.CEP = this.CEP;
            Clone.Cidade = this.Cidade;
            Clone.TipoLogradouro = this.TipoLogradouro;
            Clone.TipoResidencia = this.TipoResidencia;
            Clone.Observacao = this.Observacao;
            Clone.Principal = this.Principal;
            Clone.ClienteId = this.ClienteId;
            Clone.Cliente = this.Cliente;

            return Clone;
        }


    }
}
