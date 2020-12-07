using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class BuscarDadosClientesCommand : ICommand
    {
        public Fachada Fachada { get; set; }
        public BuscarDadosClientesCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            Fachada.SessionLink = SessionLink;

            return Fachada.BuscarDados(Objeto);
        }
    }
}
