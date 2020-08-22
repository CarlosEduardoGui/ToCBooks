using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Models;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorLivro : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var Livro = (LivrosModel)Objeto;

            if (Livro.Titulo.Equals("") || Livro.Titulo == null)
                throw new Exception("O Titulo do Livro está inconsistente...");

            if (Livro.Descricao.Equals("") || Livro.Descricao == null)
                throw new Exception("A Descricao do Livro está inconsistente...");

            //if (Livro.Foto.Equals("") || Livro.Foto == null)
            //    throw new Exception("A Foto do Livro está inconsistente...");

            if (Livro.Preco <= 0.00)
                throw new Exception("O Preço do livro está inconsistente...");

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
