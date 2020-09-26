using System.Collections.Generic;

namespace ToCBooks.App.Business.Models
{
    public class Carrinho : EntidadeDominio
    {
        public Carrinho()
        {
            Itens = new List<ItemEstoque>();
        }

        public List<ItemEstoque> Itens { get; set; }
    }
}
