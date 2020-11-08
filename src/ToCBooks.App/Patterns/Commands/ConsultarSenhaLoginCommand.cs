﻿using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;

namespace ToCBooks.App.Patterns.Commands
{
    public class ConsultarSenhaLoginCommand : ICommand
    {
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            return new Fachada().ConsultarSenhaLogin(Objeto);
        }
    }
}