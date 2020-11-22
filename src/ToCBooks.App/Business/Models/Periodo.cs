using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToCBooks.App.Business.Models
{
    public class Periodo : EntidadeDominio
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
