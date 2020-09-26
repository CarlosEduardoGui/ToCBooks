using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorCupom : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if (Objeto == null)
                throw new Exception("Objeto inválido");

            var Cupom = (CupomModel)Objeto;

            if (Cupom.Desconto == 0)
                throw new Exception("Valor de Desconto não pode ser 0");

            if (Cupom.Nome == null)
                throw new Exception("Nome do Desconto não pode esta vazio");

            if (Cupom.Nome.Contains(" "))
                throw new Exception("Nome do Desconto não pode conter espaços em branco");

            var Mensagem = new MensagemModel
            {
                Codigo = ETipoCodigo.Correto,
                Dados = null,
                Resposta = "Cupom validado com sucesso"
            };

            return Mensagem;
        }
    }
}
