using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class AtualizarSenhaCommand : ICommand
    {
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return new Fachada().Atualizar(Objeto);
        }
    }
}
