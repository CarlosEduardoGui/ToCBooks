using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorCliente : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if (Objeto == null)
                throw new Exception("Objeto inválido");

            var Cliente = (ClienteModel)Objeto;

            if (Cliente == null)
                throw new Exception("Dados de Cliente inconsistente...");

            if (Cliente.CPF == null)
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

            if (Cliente.Telefone.DDD.ToString().Length != 2)
                throw new Exception("DDD inconsistente...");

            if (Cliente.Telefone.Numero.ToString().Length != 9)
                throw new Exception("Número do Telefone está inconsistente...");

            if (Cliente.TipoGenero == 0)
                throw new Exception("Gênero inconsistente...");

            if (Cliente.TipoUsuario == 0)
                throw new Exception("Tipo Usuário inconsistente...");

            foreach (var cartaoCredito in Cliente.CartaoCredito)
            {
                if (cartaoCredito.NumeroCartao == null || cartaoCredito.NumeroCartao.Length != 19)
                    throw new Exception("Número do Cartão de Crédito inconsistente...");

                if (cartaoCredito.Nome == null || cartaoCredito.Nome.Equals(""))
                    throw new Exception("Número do Cartão de Crédito inconsistente...");

                if (cartaoCredito.CodigoSeguranca.ToString().Length != 3)
                    throw new Exception("Código de Segurança do Cartão de Crédito inconsistente...");

                if (cartaoCredito.Bandeira == 0)
                    throw new Exception("Bandeira do Cartão de Crédito inconsistente...");

                if (cartaoCredito.DataVencimento == default)
                    throw new Exception("Data de Vencimento do Cartão de Crédito inconsistente...");
            }


            foreach (var enderecoCobranca in Cliente.EnderecoCobranca)
            {
                if (enderecoCobranca.CEP.ToString().Length != 8)
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
            }


            foreach (var enderecoEntrega in Cliente.EnderecoCobranca)
            {
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
            }


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
