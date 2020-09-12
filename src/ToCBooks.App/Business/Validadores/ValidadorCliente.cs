using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorCliente : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if(Objeto == null)
                throw new Exception("Objeto inválido");

            var Cliente = (ClienteModel)Objeto;

            if (Cliente == null)
                throw new Exception("Dados de Cliente inconsistente...");

            if(Cliente.CPF == null)
                throw new Exception("CPF inconsistente...");

            if (!CpfValidacao.Validar(Cliente.CPF.ToString()))
                throw new Exception("CPF inválido...");

            if (Cliente.DataNascimento.Equals("") || Cliente.DataNascimento == null || Cliente.DataNascimento == default)
                throw new Exception("Data de Nascimento inconsistente...");

            if (Cliente.Login.Email.Equals("") || Cliente.Login.Email == null)
                throw new Exception("Email inconsistente...");

            if (Cliente.Nome.Equals("") || Cliente.Nome == null)
                throw new Exception("Nome inconsistente...");

            if (Cliente.Login.Senha.Equals("") || Cliente.Login.Senha == null)
                throw new Exception("Nome inconsistente...");

            if (Cliente.Telefone == null)
                throw new Exception("Telefone inconsistente...");

            if (Cliente.Telefone.DDD == 0 || Cliente.Telefone.DDD > 99)
                throw new Exception("DDD inconsistente...");

            if (Cliente.Telefone.Numero == 0 || Cliente.Telefone.Numero > 999999999)
                throw new Exception("Número do Telefone está inconsistente...");

            if (Cliente.TipoGenero == 0)
                throw new Exception("Gênero inconsistente...");

            if (Cliente.TipoUsuario == 0)
                throw new Exception("Tipo Usuário inconsistente...");

            if (Cliente.CartaoCredito.NumeroCartao.Equals("") || Cliente.CartaoCredito.NumeroCartao == null)
                throw new Exception("Número do Cartão de Crédito inconsistente...");

            if (Cliente.CartaoCredito.Nome == null || Cliente.CartaoCredito.Nome.Equals(""))
                throw new Exception("Número do Cartão de Crédito inconsistente...");

            if (Cliente.CartaoCredito.CodigoSeguranca == 0 || Cliente.CartaoCredito.CodigoSeguranca <= 0)
                throw new Exception("Código de Segurança do Cartão de Crédito inconsistente...");

            if (Cliente.CartaoCredito.Bandeira == 0)
                throw new Exception("Bandeira do Cartão de Crédito inconsistente...");

            #region Endereco Cobrança

            if (Cliente.EnderecoCobranca.CEP == 0 || Cliente.EnderecoCobranca.CEP > 99999999)
                throw new Exception("CEP inconsistente...");

            if (Cliente.EnderecoCobranca.Bairro == null || Cliente.EnderecoCobranca.Bairro.Equals(""))
                throw new Exception("Bairro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoCobranca.Nome == null || Cliente.EnderecoCobranca.Nome.Equals(""))
                throw new Exception("Logradouro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoCobranca.Numero == 0)
                throw new Exception("Número do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoCobranca.TipoLogradouro == 0)
                throw new Exception("Tipo de Logradouro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoCobranca.TipoResidencia == 0)
                throw new Exception("Tipo de Residência do Endereço Cobrança inconsistente...");

            #endregion

            #region Endereço Entrega

            if (Cliente.EnderecoEntrega.CEP == 0 || Cliente.EnderecoEntrega.CEP > 99999999)
                throw new Exception("CEP inconsistente...");

            if (Cliente.EnderecoEntrega.Bairro == null || Cliente.EnderecoEntrega.Bairro.Equals(""))
                throw new Exception("Bairro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoEntrega.Nome == null || Cliente.EnderecoEntrega.Nome.Equals(""))
                throw new Exception("Logradouro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoEntrega.Numero == 0)
                throw new Exception("Número do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoEntrega.TipoLogradouro == 0)
                throw new Exception("Tipo de Logradouro do Endereço Cobrança inconsistente...");

            if (Cliente.EnderecoEntrega.TipoResidencia == 0)
                throw new Exception("Tipo de Residência do Endereço Cobrança inconsistente...");

            #endregion


            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Dados Validados Com Sucesso !!!",
                Dados = null
            };

            return Mensagem;
        }
    }
}
