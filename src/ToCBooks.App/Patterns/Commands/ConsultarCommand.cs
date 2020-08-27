using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;
using ToCBooks.App.Business.Models;
using System.Threading.Tasks;
using System;

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
            return this.Fachada.Consultar(Objeto);
        }

    }
}
