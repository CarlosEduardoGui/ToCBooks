using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorAtualizarDadosCliente : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var Mensagem = new MensagemModel();
            try
            {
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

                if (Cliente.TipoGenero == 0)
                    throw new Exception("Gênero inconsistente...");

                if(Cliente.Telefone.DDD == 0)
                    throw new Exception("DDD do Telefone inconsistente...");
            
                if(Cliente.Telefone.Numero == 0)
                    throw new Exception("Número do Telefone inconsistente...");

                Mensagem.Codigo = ETipoCodigo.Correto;
                Mensagem.Resposta = "Cliente validado com sucesso";

                return Mensagem;
            }
            catch (Exception ex)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = ex.Message;

                return Mensagem;
            }
        }
    }
}
