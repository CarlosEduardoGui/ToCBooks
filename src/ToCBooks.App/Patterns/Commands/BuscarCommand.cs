using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class BuscarCommand : ICommand
    {
        private Fachada Fachada;
        public BuscarCommand()
        {
            Fachada = new Fachada();
        }
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return Fachada.Buscar(Objeto);
        }
    }
}
