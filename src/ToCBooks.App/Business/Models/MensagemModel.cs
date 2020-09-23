using System.Collections.Generic;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class MensagemModel
    {
        public MensagemModel()
        {
            Dados = new List<EntidadeDominio>();
        }

        public ETipoCodigo Codigo { get; set; }
        public string Resposta { get; set; }
        public List<EntidadeDominio> Dados { get; set; }
    }
}
