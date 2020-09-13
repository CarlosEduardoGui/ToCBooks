using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorCartaoCredito : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {

            if (Objeto == null)
                throw new Exception("Objeto inconsistente");

            var CartaoCredito = (CartaoCreditoModel)Objeto;

            if (CartaoCredito.NumeroCartao == null || CartaoCredito.NumeroCartao.Length != 19)
                throw new Exception("Número do Cartão de Crédito inconsistente...");

            if (CartaoCredito.Nome == null || CartaoCredito.Nome.Equals(""))
                throw new Exception("Número do Cartão de Crédito inconsistente...");

            if (CartaoCredito.CodigoSeguranca.ToString().Length != 3)
                throw new Exception("Código de Segurança do Cartão de Crédito inconsistente...");

            if (CartaoCredito.Bandeira == 0)
                throw new Exception("Bandeira do Cartão de Crédito inconsistente...");

            if (CartaoCredito.DataVencimento == default)
                throw new Exception("Data de Vencimento do Cartão de Crédito inconsistente...");


            return new MensagemModel { Codigo = 0, Dados = null, Resposta = "Dados consistentes" };
        }
    }
}
