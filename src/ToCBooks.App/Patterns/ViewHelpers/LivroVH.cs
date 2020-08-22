using ToCBooks.App.Models;
using Newtonsoft.Json;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.ViewHelpers
{
    public class LivroVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            return JsonConvert.DeserializeObject<LivrosModel>(JsonString);
        }
    }
}
