using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToCBooks.App.Business.Models
{
    public class Carrinho : EntidadeDominio
    {
        public Carrinho()
        {
            Itens = new List<ItemEstoque>();
        }

        public List<ItemEstoque> Itens { get; set; }
        [NotMapped]
        public float DescontoCredito { get; set; }
    }
}
