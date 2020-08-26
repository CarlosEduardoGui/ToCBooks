using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Patterns.Interfaces
{
    public interface IFachada
    {
        MensagemModel Consultar(EntidadeDominio Objeto);
        MensagemModel Cadastrar(EntidadeDominio Objeto);
        MensagemModel Atualizar(EntidadeDominio Objeto);
        MensagemModel Excluir(EntidadeDominio Objeto);
    }
}
