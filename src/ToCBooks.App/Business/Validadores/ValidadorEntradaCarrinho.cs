using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.DAOs;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorEntradaCarrinho : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            var ItemEstoqueRecebido = (ItemEstoque)Despachante.Entidade;
            var ItemEstoqueAtual = (ItemEstoque)new EstoqueDAO().ConsultarQuantidade(Despachante).Dados.FirstOrDefault();

            if (ItemEstoqueAtual == null)
                throw new Exception("Não Possuímos Unidades desse Livro no Estoque...");
            if (ItemEstoqueRecebido.Qtde > ItemEstoqueAtual.Qtde)
                throw new Exception("Só possuimos " + ItemEstoqueAtual.Qtde + " Unidades em estoque");

            MensagemModel Mensagem = new MensagemModel();
            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Item de Estoque validado com sucesso !!!";

            return Mensagem;
        }
    }
}
