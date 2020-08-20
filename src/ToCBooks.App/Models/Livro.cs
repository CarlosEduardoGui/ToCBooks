using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToCBooks.App.Models
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
    }
}
