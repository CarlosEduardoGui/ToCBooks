using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Interfaces
{
    public interface IStrategy
    {
        MensagemModel Validar(EntidadeDominio Objeto);
    }
}
