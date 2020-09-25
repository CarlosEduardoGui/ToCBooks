using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
