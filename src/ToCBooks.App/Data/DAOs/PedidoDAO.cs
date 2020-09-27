using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class PedidoDAO : IDAO
    {
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
                var Pedido = (PedidoModel)Objeto;
                Pedido.ItensPedido.ForEach(x => db.Livro.Attach(x.Livro));
                db.Cliente.Attach(Pedido.Cliente);
                db.EnderecoEntrega.Attach(Pedido.EnderecoEntrega);
                Pedido.CartoesCredito.ForEach(x => db.CartaoCredito.Attach(x));
                db.Pedido.Add(Pedido);
                db.SaveChanges();
            }

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = ETipoCodigo.Correto,
                Resposta = "Venda Registrada...",
            };

            return Mensagem;
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
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
