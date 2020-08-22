using System.Threading.Tasks;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Interfaces
{
    public interface ICommand
    {
        Task<MensagemModel> Executar(EntidadeDominio Objeto);
    }
}
