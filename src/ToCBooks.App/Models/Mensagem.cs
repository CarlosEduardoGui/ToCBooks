using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToCBooks.App.Models
{
    public class Mensagem
    {
        public int Codigo { get; set; }
        public string Resposta { get; set; }
        public List<Entidade> Dados { get; set; }
    }
}
