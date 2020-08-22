using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Interfaces
{
    public interface IViewHelper
    {
        EntidadeDominio GetEntidade(string JsonString);
    }
}
