using System.Threading.Tasks;
using ToCBooks.Business.Models;
using ToCBooks.Data.Models;

namespace ToCBooks.App.Patterns.Interfaces
{
    public interface IFachada
    {
        Task<MensagemModel> Consultar(EntidadeDominio Objeto);
        Task<MensagemModel> Cadastrar(EntidadeDominio Objeto);
        Task<MensagemModel> Atualizar(EntidadeDominio Objeto);
        Task<MensagemModel> Excluir(EntidadeDominio Objeto);
    }
}
