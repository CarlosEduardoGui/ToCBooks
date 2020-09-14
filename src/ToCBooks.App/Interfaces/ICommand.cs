using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Interfaces
{
    public interface ICommand
    {
        MensagemModel Executar(EntidadeDominio Objeto);
    }
}
