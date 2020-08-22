using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;
using ToCBooks.App.Business.Models;
using System.Threading.Tasks;

namespace ToCBooks.App.Commands
{
    public class ConsultarLivrosCommand : ICommand
    {
        private readonly Fachada Fachada;
        public ConsultarLivrosCommand()
        {
            Fachada = new Fachada();
        }

        public Task<MensagemModel> Executar(EntidadeDominio Objeto)
        {
            return Fachada.Consultar(Objeto);
        }
    }
}
