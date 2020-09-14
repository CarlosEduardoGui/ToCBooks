using Newtonsoft.Json;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;

namespace ToCBooks.App.Patterns.ViewHelpers
{
    public class ParametroVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            return JsonConvert.DeserializeObject<Parametro>(JsonString);
        }
    }
}
