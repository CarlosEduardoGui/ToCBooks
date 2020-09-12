using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class LoginCommand : ICommand
    {
        private Fachada Fachada;
        public LoginCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto)
        {
            return Fachada.Login(Objeto);
        }
    }
}
