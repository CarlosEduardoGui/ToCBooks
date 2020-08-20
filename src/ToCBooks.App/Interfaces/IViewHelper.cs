using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Models;

namespace ToCBooks.App.Interfaces
{
    interface IViewHelper
    {
        Entidade GetEntidade(string JsonString);
    }
}
