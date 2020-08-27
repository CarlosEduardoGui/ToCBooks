using Newtonsoft.Json;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.Patterns.ViewHelpers
{
    public class ClienteVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            var result = JsonConvert.DeserializeObject<ClienteModel>(JsonString);

            return result;
        }
    }
}
