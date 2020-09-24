using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Commands
{
    public class ConsultarCommand : ICommand
    {
        private readonly Fachada Fachada;
        public ConsultarCommand()
        {
            Fachada = new Fachada();
        }


        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return this.Fachada.Consultar(Objeto);
        }

    }
}
