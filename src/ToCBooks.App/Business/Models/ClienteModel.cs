using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class ClienteModel : EntidadeDominio
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Observacao { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public TelefoneModel Telefone { get; set; }

        //public DateTime DataNascimento { get; set; }

        public EnderecoCobrancaModel EnderecoCobranca { get; set; }

        public EnderecoEntregaModel EnderecoEntrega { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }

        public ETipoGenero TipoGenero { get; set; }
    }
}
