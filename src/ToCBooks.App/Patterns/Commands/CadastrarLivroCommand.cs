using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class CadastrarLivroCommand : ICommand
    {
        private readonly Fachada Fachada;
        public CadastrarLivroCommand()
        {
            Fachada = new Fachada();
        }

        public Task<MensagemModel> Executar(EntidadeDominio Objeto)
        {
            return Fachada.Cadastrar(Objeto);
        }
    }
}
