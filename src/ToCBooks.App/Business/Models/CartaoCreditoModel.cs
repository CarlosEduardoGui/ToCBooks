using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class CartaoCreditoModel : EntidadeDominio
    {
        public string NumeroCartao { get; set; }

        public string Nome { get; set; }

        public int CodigoSeguranca { get; set; }

        public ETipoBandeira Bandeira { get; set; }

        public bool Principal { get; set; }
    }
}
