using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class DesativarCommand : ICommand
    {
        private Fachada Fachada;
        public DesativarCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto)
        {
            return Fachada.DesativarRegistro(Objeto);
        }
    }
}
