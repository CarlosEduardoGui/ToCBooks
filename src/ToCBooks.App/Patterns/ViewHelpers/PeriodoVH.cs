using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;

namespace ToCBooks.App.Patterns.ViewHelpers
{
    public class PeriodoVH : IViewHelper
    {
        public EntidadeDominio GetEntidade(string JsonString)
        {
            return JsonConvert.DeserializeObject<Periodo>(JsonString);
        }
    }
}
