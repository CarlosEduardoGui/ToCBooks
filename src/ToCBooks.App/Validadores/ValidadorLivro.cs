using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.Validadores
{
    public class ValidadorLivro : IStrategy
    {
        public Mensagem Validar(Entidade Objeto)
        {
            Livro Livro = (Livro)Objeto;

            if (Livro.Titulo.Equals("") || Livro.Titulo == null)
                throw new Exception("O Titulo do Livro está inconsistente...");
            if (Livro.Descricao.Equals("") || Livro.Descricao == null)
                throw new Exception("A Descricao do Livro está inconsistente...");
            if (Livro.Foto.Equals("") || Livro.Foto == null)
                throw new Exception("A Foto do Livro está inconsistente...");
            if (Livro.Preco <= 0.00)
                throw new Exception("O Preço do livro está inconsistente...");

            Mensagem Mensagem = new Mensagem();
            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Validados Com Sucesso !!!";
            Mensagem.Dados = null;

            return Mensagem;
        }
    }
}
