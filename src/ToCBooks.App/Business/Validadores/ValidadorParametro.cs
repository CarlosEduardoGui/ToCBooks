using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorParametro : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            Parametro Parametro = (Parametro)Objeto;

            if (Parametro.Nome.Equals("") || Parametro.Nome == null)
                throw new Exception("Nome Inválido...");
            if (Parametro.Valor <= 0)
                throw new Exception("Valor Inválido...");

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Dados Validados",
                Dados = null
            };

            return Mensagem;
        }
    }
}
