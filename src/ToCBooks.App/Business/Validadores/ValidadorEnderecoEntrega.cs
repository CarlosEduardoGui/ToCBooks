using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorEnderecoEntrega : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if (Objeto == null)
                throw new Exception("Objeto inconsistente");

            var enderecoEntrega = (EnderecoEntregaModel)Objeto;

            if (enderecoEntrega.CEP.ToString().Length != 8)
                throw new Exception("CEP inconsistente...");

            if (enderecoEntrega.Bairro == null || enderecoEntrega.Bairro.Equals(""))
                throw new Exception("Bairro do Endereço Cobrança inconsistente...");

            if (enderecoEntrega.Nome == null || enderecoEntrega.Nome.Equals(""))
                throw new Exception("Logradouro do Endereço Cobrança inconsistente...");

            if (enderecoEntrega.Numero == 0)
                throw new Exception("Número do Endereço Cobrança inconsistente...");

            if (enderecoEntrega.TipoLogradouro == 0)
                throw new Exception("Tipo de Logradouro do Endereço Cobrança inconsistente...");

            if (enderecoEntrega.TipoResidencia == 0)
                throw new Exception("Tipo de Residência do Endereço Cobrança inconsistente...");


            return new MensagemModel { Codigo = 0, Dados = null, Resposta = "Dados Consistentes" };
        }
    }
}
