namespace ToCBooks.App.Business.Models
{
    public class ItemPedido : EntidadeDominio
    {
        public int Qtde { get; set; }
        public LivrosModel Livro { get; set; }
        public PedidoModel Pedido { get; set; }
    }
}
