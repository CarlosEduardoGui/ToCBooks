﻿using Newtonsoft.Json;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;

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
