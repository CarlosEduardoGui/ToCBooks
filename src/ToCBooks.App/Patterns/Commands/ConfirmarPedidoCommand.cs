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
    public class ConfirmarPedidoCommand : ICommand
    {
        public Fachada Fachada { get; set; }
        public ConfirmarPedidoCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            Fachada.SessionLink = SessionLink;
            return Fachada.ConfirmarCompra((Despachante)Objeto);
        }
    }
}
