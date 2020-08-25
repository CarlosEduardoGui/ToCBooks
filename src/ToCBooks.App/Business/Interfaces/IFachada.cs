using System.Threading.Tasks;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Patterns.Interfaces
{
    public interface IFachada
    {
        MensagemModel Consultar(EntidadeDominio Objeto);
        MensagemModel Cadastrar(EntidadeDominio Objeto);
        Task<MensagemModel> Atualizar(EntidadeDominio Objeto);
        Task<MensagemModel> Excluir(EntidadeDominio Objeto);
    }
}
