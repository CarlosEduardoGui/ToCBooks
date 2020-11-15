using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorLogin : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if (Objeto == null)
                throw new Exception("Objeto inválido");

            var Login = (LoginModel)Objeto;


            if (Login.Email == null || Login.Email.Equals("") || Login.Email.Equals(" "))
                throw new Exception("Email está inconsistente...");

            if (Login.Senha == null || Login.Senha.Equals("") || Login.Senha.Equals(" "))
                throw new Exception("Senha está inconsistente...");

            if (!ValidadorSenhaForte.VerificaSenhaForte(Login.Senha))
                throw new Exception("Senha está inconsistente...");


            var Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Validado com sucesso",
                Dados = null
            };

            return Mensagem;
        }
    }
}
