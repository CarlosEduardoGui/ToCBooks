using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class AdicionarItemCarrinhoCommand : ICommand
    {
        private Fachada Fachada { get; set; }

        public AdicionarItemCarrinhoCommand()
        {
            Fachada = new Fachada();
        }
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            Fachada.SessionLink = SessionLink;
            return Fachada.AdicionarItemCarrinho(Objeto);
        }
    }
}
