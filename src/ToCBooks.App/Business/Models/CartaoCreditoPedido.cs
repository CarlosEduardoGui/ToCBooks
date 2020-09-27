using System;

namespace ToCBooks.App.Business.Models
{
    public class CartaoCreditoPedido
    {
        public Guid Id { get; set; }
        public Guid CartaoCreditoID { get; set; }
        public Guid PedidoId { get; set; }

        public CartaoCreditoModel CartaoCredito { get; set; }
        public PedidoModel Pedido { get; set; }
    }
}
