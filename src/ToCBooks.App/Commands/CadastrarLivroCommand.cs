using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Controllers;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.Commands
{
    public class CadastrarLivroCommand : ICommand
    {
        private Fachada Fachada;
        public CadastrarLivroCommand()
        {
            Fachada = new Fachada();
        }

        public Mensagem Executar(Entidade Objeto)
        {
            return Fachada.Cadastrar(Objeto);
        }
    }
}
