using System;
using System.Collections.Generic;
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

            if (ValidarFoto(Livro.Foto))
                throw new Exception("A Foto do Livro está inconsistente...");

            if (Livro.Preco < 0.00)
                throw new Exception("O Preço do livro está inconsistente...");

            if (Livro.Autor.Equals("") || Livro.Autor == null)
                throw new Exception("O Autor do Livro está inconsistente...");

            if (Livro.Editora.Equals("") || Livro.Editora == null)
                throw new Exception("A Editora do Livro está inconsistente...");

            if (Livro.Ano.Equals("") || Livro.Ano <= 0)
                throw new Exception("O Ano do Livro está inconsistente...");

            if (Livro.Edicao.Equals("") || Livro.Edicao <= 0)
                throw new Exception("A Edição do Livro está inconsistente...");

            if (Livro.ISBN.Equals("") || Livro.ISBN == null)
                throw new Exception("O ISBN do Livro está inconsistente...");

            if (Livro.Paginas.Equals("") || Livro.Paginas <= 0)
                throw new Exception("A Quantidade de Paginas do Livro está inconsistente...");

            if (Livro.Altura.Equals("") || Livro.Altura <= 0)
                throw new Exception("A Altura do Livro está inconsistente...");

            if (Livro.Largura.Equals("") || Livro.Largura <= 0)
                throw new Exception("A Largura do Livro está inconsistente...");

            if (Livro.Profundidade.Equals("") || Livro.Profundidade <= 0)
                throw new Exception("A Profundidade do Livro está inconsistente...");

            if (Livro.Peso.Equals("") || Livro.Peso <= 0)
                throw new Exception("O Peso do Livro está inconsistente...");

            if (Livro.CodigoDeBarras.Equals("") || Livro.CodigoDeBarras == null)
                throw new Exception("O Codigo De Barras do Livro está inconsistente...");

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Dados Validados Com Sucesso !!!",
                Dados = null
            };

            return Mensagem;
        }

        private bool ValidarFoto(string base64)
        {
            List<string> ExtensoesAceitar = new List<string>
            {
                "jpeg", "jpg", "png", "gif"
            };

            string Extensao = base64.Split(",")[0].Replace("data:image/", "").Split(";")[0];

            return base64.Equals("") || base64 == null || !ExtensoesAceitar.Contains(Extensao);

        }

    }
}
