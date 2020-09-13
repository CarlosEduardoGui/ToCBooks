using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToCBooks.App.Business.Models
{
    public class Despachante : EntidadeDominio
    {
        public EntidadeDominio Entidade { get; set; }
        public LoginModel Login { get; set; }
    }
}
