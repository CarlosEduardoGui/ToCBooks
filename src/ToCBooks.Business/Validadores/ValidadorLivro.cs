using System;
using ToCBooks.Business.Interfaces;
using ToCBooks.Business.Models;

namespace ToCBooks.Business.Patterns.Validadores
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
            if (Livro.Foto.Equals("") || Livro.Foto == null)
                throw new Exception("A Foto do Livro está inconsistente...");
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
