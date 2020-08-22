using ToCBooks.Business.Models;
using ToCBooks.Data.Models;

namespace ToCBooks.Business.Interfaces
{
    public interface IStrategy
    {
        MensagemModel Validar(EntidadeDominio Objeto);
    }
}
