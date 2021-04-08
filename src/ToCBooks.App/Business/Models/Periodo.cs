using System;

namespace ToCBooks.App.Business.Models
{
    public class Periodo : EntidadeDominio
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
