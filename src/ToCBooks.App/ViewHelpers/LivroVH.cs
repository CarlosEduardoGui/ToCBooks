using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;
using Newtonsoft.Json;

namespace ToCBooks.App.ViewHelpers
{
    public class LivroVH : IViewHelper
    {
        public Entidade GetEntidade(string JsonString)
        {
            return JsonConvert.DeserializeObject<Livro>(JsonString);
        }
    }
}
