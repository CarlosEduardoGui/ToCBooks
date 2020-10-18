using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToCBooks.App.Business.Models
{
    public class PedidoModel : EntidadeDominio
    {
        public PedidoModel()
        {
            CartaoCreditoPedido = new List<CartaoCreditoPedido>();
            ItensPedido = new List<ItemPedido>();
        }

        public EnderecoEntregaModel EnderecoEntrega { get; set; }

        [NotMapped]
        public List<CartaoCreditoModel> CartoesCredito { get; set; }

        public ClienteModel Cliente { get; set; }

        public List<ItemPedido> ItensPedido { get; set; }
        public float DescontoPorCredito { get; set; }

        public CupomModel CupomDesconto { get; set; }

        public double TotalPedido { get; set; }

        public List<CartaoCreditoPedido> CartaoCreditoPedido { get; set; }
    }
}
