using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class CartaoCreditoDAO : IDAO
    {
        private MensagemModel mensagem;
        private int result;

        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var CartaoCredito = (CartaoCreditoModel)Objeto;

                db.Add(CartaoCredito);
                result = db.SaveChanges();

                if (result == 1)
                {
                    mensagem.Codigo = 0;
                    mensagem.Dados = null;
                    mensagem.Resposta = "Cartão de Crédito cadastrado com sucesso!";

                    return mensagem;
                }

                mensagem.Codigo = 1;
                mensagem.Resposta = "Erro ao cadastrar Cartão de Crédito";

                return mensagem;
            }
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var CartaoCredito = (CartaoCreditoModel)Objeto;

                mensagem.Dados.Add(db.CartaoCredito.Find(CartaoCredito.ClienteId));

            }

            throw new NotImplementedException();
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MensagemModel Editar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
