﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class PedidoDAO : IDAO
    {
        private MensagemModel mensagem = new MensagemModel();

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

                if(Pedido.CupomDesconto != null)
                    db.Cupom.Update(Pedido.CupomDesconto);

                db.Pedido.Add(Pedido);
                db.SaveChanges();
            }

            mensagem.Codigo = ETipoCodigo.Correto;
            mensagem.Resposta = "Venda Registrada...";


            return mensagem;
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Despachante = (Despachante)Objeto;
                var Pedido = (PedidoModel)Despachante.Entidade;

                db.Pedido
                .Include(x => x.Cliente)
                .Include(x => x.EnderecoEntrega)
                .Where(x => x.StatusAtual == ETipoStatus.EmProcessamento).ToList()
                .ForEach(x =>
                {
                    x.Cliente.EnderecoEntrega.ForEach(y =>
                    {
                        y.Cliente = null;
                        y = db.EnderecoEntrega
                        .Include(z => z.Cidade)
                        .Include(z => z.Cidade.Estado)
                        .Include(z => z.Cidade.Estado.Pais)
                        .Where(z => z.Id == y.Id).First();
                    });

                    mensagem.Dados.Add(x);
                });
            }

            mensagem.Codigo = ETipoCodigo.Correto;
            mensagem.Resposta = "Venda Consultada...";

            return mensagem;
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
