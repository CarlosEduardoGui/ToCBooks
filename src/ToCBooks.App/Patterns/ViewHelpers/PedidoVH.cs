using Newtonsoft.Json;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;

namespace ToCBooks.App.Patterns.ViewHelpers
{
    public class PedidoVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            return JsonConvert.DeserializeObject<PedidoModel>(JsonString);
        }
    }
}
