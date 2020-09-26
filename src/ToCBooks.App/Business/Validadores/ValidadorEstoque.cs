using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Data.DAOs;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorEstoque : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var ItemEstoque = (ItemEstoque)Objeto;

            if (ItemEstoque.Qtde <= 0)
                throw new Exception("Quantidade de Livro Inconsistente...");
            if (new LivrosDAO().Consultar(ItemEstoque.Livro).Codigo != 0)
                throw new Exception("O Livro em questão não foi encontrado no Estoque...");

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Item de Estoque Validado com Sucesso..."
            };

            return Mensagem;
        }
    }
}
