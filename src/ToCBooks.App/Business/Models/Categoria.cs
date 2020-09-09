using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToCBooks.App.Business.Models
{
    public class Categoria : EntidadeDominio
    {
        public string NomeCategoria { get; set; }
    }
}
