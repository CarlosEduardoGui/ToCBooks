using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorEnderecoCobranca : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {

            if (Objeto == null)
                throw new Exception("Objeto inconsistente");

            var enderecoCobranca = (EnderecoCobrancaModel)Objeto;

            if (enderecoCobranca.CEP == null)
                throw new Exception("CEP inconsistente...");

            if (enderecoCobranca.Bairro == null || enderecoCobranca.Bairro.Equals(""))
                throw new Exception("Bairro do Endereço Cobrança inconsistente...");

            if (enderecoCobranca.Nome == null || enderecoCobranca.Nome.Equals(""))
                throw new Exception("Logradouro do Endereço Cobrança inconsistente...");

            if (enderecoCobranca.Numero == 0)
                throw new Exception("Número do Endereço Cobrança inconsistente...");

            if (enderecoCobranca.TipoLogradouro == 0)
                throw new Exception("Tipo de Logradouro do Endereço Cobrança inconsistente...");

            if (enderecoCobranca.TipoResidencia == 0)
                throw new Exception("Tipo de Residência do Endereço Cobrança inconsistente...");


            return new MensagemModel { Codigo = 0, Dados = null, Resposta = "Dados consistentes" };

        }
    }
}
