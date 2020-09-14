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

            if (Cliente.EnderecoCobranca != null)
            {
                foreach (var enderecoCobranca in Cliente.EnderecoCobranca)
                    new ValidadorEnderecoCobranca().Validar(enderecoCobranca);

            }

            if (Cliente.EnderecoEntrega != null)
            {
                foreach (var enderecoEntrega in Cliente.EnderecoEntrega)
                    new ValidadorEnderecoEntrega().Validar(enderecoEntrega);
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
