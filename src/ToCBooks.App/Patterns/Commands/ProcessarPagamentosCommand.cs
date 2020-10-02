using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class ProcessarPagamentosCommand : ICommand
    {
        public Fachada Fachada { get; set; }

        public ProcessarPagamentosCommand()
        {
            Fachada = new Fachada();
        }
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return Fachada.ProcessarPagamentos();
        }
    }
}
