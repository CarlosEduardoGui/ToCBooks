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

            //Gambiarra
            if (Cliente.Login.Senha != null) //Cliente.Login.Senha.Equals("") || 
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

            //Gambiarra
            if (Cliente.CartaoCredito != null)
            {
                foreach (var cartaoCredito in Cliente.CartaoCredito)
                    new ValidadorCartaoCredito().Validar(cartaoCredito);

            }


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
