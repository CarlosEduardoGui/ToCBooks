using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class ClienteModel : EntidadeDominio
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public LoginModel Login { get; set; }

        public TelefoneModel Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<EnderecoCobrancaModel> EnderecoCobranca { get; set; }

        public List<EnderecoEntregaModel> EnderecoEntrega { get; set; }

        public List<CartaoCreditoModel> CartaoCredito { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }

        public ETipoGenero TipoGenero { get; set; }

        public bool Ativo { get; set; }
    }
}
