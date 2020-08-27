using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Commands
{
    public class ConsultarCommand : ICommand
    {
        private readonly Fachada Fachada;
        public ConsultarCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto)
        {
            return Fachada.Consultar(Objeto);
        }
    }
}
