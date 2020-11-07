using System;
using System.Linq;
using System.Text.RegularExpressions;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorSenhaForte : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var Mensagem = new MensagemModel();

            if (Objeto == null)
                throw new Exception("Objeto inválido.");

            var Cliente = (ClienteModel)Objeto;

            if (Cliente.Login.Senha == null)
                throw new Exception("Campo Senha inválido.");

            if (!VerificaSenhaForte(Cliente.Login.Senha))
                throw new Exception("Senha inserida não é uma senha forte.");

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Senha válida";

            return Mensagem;

        }

        public static bool VerificaSenhaForte(string senha)
        {
            if (senha.Length < 8)
                return false;

            if (!senha.Any(x => char.IsDigit(x)))
                return false;

            if(!senha.Any(x => char.IsUpper(x)))
                return false;

            if (!senha.Any(x => char.IsLower(x)))
                return false;

            if (!senha.Any(x => char.IsLetterOrDigit(x)))
                return false;

            return true;
        }
    }
}
