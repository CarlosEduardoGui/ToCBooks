using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class AtivarCommand : ICommand
    {
        private Fachada Fachada;

        public AtivarCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto)
        {
            return Fachada.AtivarRegistro(Objeto);
        }
    }
}
