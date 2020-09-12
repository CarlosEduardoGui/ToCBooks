using Newtonsoft.Json;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;

namespace ToCBooks.App.Patterns.ViewHelpers
{
    public class LoginVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            var result = JsonConvert.DeserializeObject<LoginModel>(JsonString);

            return result;
        }
    }
}
