﻿using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class AtualizarPrecoCommand : ICommand
    {
        private Fachada Fachada;

        public AtualizarPrecoCommand()
        {
            Fachada = new Fachada();
        }

        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return Fachada.AtualizarPreco(Objeto);
        }
    }
}
