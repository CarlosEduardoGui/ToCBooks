using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            MensagemModel Mensagem = new MensagemModel();
            var Pedido = (PedidoModel)Objeto;

            using (var db = new ToCBooksContext())
            {
                db.Pedido.Update(Pedido);
                db.SaveChanges();
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Item Atualizado Com Suscesso...";

            return Mensagem;
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

                if (Pedido.CupomDesconto != null)
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

        public MensagemModel ConsultarPedidosPendentes()
        {
            MensagemModel Mensagem = new MensagemModel();

            using (var db = new ToCBooksContext())
            {
                db.Pedido
                .Include(x => x.Cliente)
                .Include(x => x.EnderecoEntrega)
                .Include(x => x.ItensPedido)
                .Include(x => x.CartaoCreditoPedido)
                .Where(x => x.StatusAtual == ETipoStatus.EmProcessamento).ToList()
                .ForEach(x =>
                {
                    x.CartoesCredito = new List<CartaoCreditoModel>();
                    x.CartaoCreditoPedido.ForEach(y => x.CartoesCredito.Add(db.CartaoCredito.Where(z => z.Id == y.CartaoCreditoID).FirstOrDefault()));

                    x.Cliente.EnderecoEntrega.ForEach(y =>
                    {
                        y.Cliente = null;
                        y = db.EnderecoEntrega
                        .Include(z => z.Cidade)
                        .Include(z => z.Cidade.Estado)
                        .Include(z => z.Cidade.Estado.Pais)
                        .Where(z => z.Id == y.Id).First();
                    });

                    x.ItensPedido.ForEach(z =>
                    {
                        z.Pedido = null;
                        z = db.ItensPedidos
                        .Include(a => a.Pedido)
                        .Include(a => a.Livro)
                        .Where(a => a.Id == z.Id).First();
                    });

                    x.CartaoCreditoPedido.ForEach(a =>
                    {
                        a.Pedido = null;
                        a = db.CartaoCreditoPedido
                        .Include(b => b.CartaoCredito)
                        .Include(b => b.Pedido)
                        .Where(b => b.Id == a.Id).First();
                    });

                    x.Cliente.CartaoCredito = null;
                    x.CartaoCreditoPedido.ForEach(c => c.CartaoCredito.CartaoCreditoPedido = null);

                    Mensagem.Dados.Add(x);
                });

                Mensagem.Codigo = ETipoCodigo.Correto;
                Mensagem.Resposta = "Pedidos Encontrados...";


                return Mensagem;
            }
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Despachante = (Despachante)Objeto;
                var Pedido = (PedidoModel)Despachante.Entidade;


                if (db.Pedido.Where(x => x.Id == Pedido.Id).Count() > 0)
                {
                    db.Pedido
                    .Include(x => x.Cliente)
                    .Include(x => x.EnderecoEntrega)
                    .Include(x => x.ItensPedido)
                    .Include(x => x.CartaoCreditoPedido)
                    .Where(x => x.Id == Pedido.Id && x.Cliente.Id == Despachante.Login.ClienteId).ToList()
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

                        x.ItensPedido.ForEach(z =>
                        {
                            z.Pedido = null;
                            z = db.ItensPedidos
                            .Include(a => a.Pedido)
                            .Include(a => a.Livro)
                            .Where(a => a.Id == z.Id).First();
                        });

                        x.CartaoCreditoPedido.ForEach(a =>
                        {
                            a.Pedido = null;
                            a = db.CartaoCreditoPedido
                            .Include(b => b.CartaoCredito)
                            .Include(b => b.Pedido)
                            .Where(b => b.Id == a.Id).First();
                        });

                        x.Cliente.CartaoCredito = null;
                        x.CartaoCreditoPedido.ForEach(c => c.CartaoCredito.CartaoCreditoPedido = null);

                        mensagem.Dados.Add(x);
                    });

                    mensagem.Codigo = ETipoCodigo.Correto;
                    mensagem.Resposta = "Pedido Consultado...";

                    return mensagem;
                }

                if (new LoginDAO().ConsultarPorId(Despachante.Login.ClienteId).Dados.Count() != 0)
                {
                    db.Pedido
                    .Include(x => x.Cliente)
                    .Include(x => x.EnderecoEntrega)
                    .Include(x => x.ItensPedido)
                    .Include(x => x.CartaoCreditoPedido)
                    .ToList()
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

                        x.ItensPedido.ForEach(z =>
                        {
                            z.Pedido = null;
                            z = db.ItensPedidos
                            .Include(a => a.Pedido)
                            .Include(a => a.Livro)
                            .Where(a => a.Id == z.Id).First();
                        });

                        x.CartaoCreditoPedido.ForEach(a =>
                        {
                            a.Pedido = null;
                            a = db.CartaoCreditoPedido
                            .Include(b => b.CartaoCredito)
                            .Include(b => b.Pedido)
                            .Where(b => b.Id == a.Id).First();
                        });

                        x.Cliente.CartaoCredito = null;
                        x.CartaoCreditoPedido.ForEach(c => c.CartaoCredito.CartaoCreditoPedido = null);

                        mensagem.Dados.Add(x);
                    });
                }
                else
                {
                    db.Pedido
                    .Include(x => x.Cliente)
                    .Include(x => x.EnderecoEntrega)
                    .Include(x => x.ItensPedido)
                    .Include(x => x.CartaoCreditoPedido)
                    .Where(x => x.Cliente.Id == Despachante.Login.ClienteId)
                    .ToList()
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

                        x.ItensPedido.ForEach(z =>
                        {
                            z.Pedido = null;
                            z = db.ItensPedidos
                            .Include(a => a.Pedido)
                            .Include(a => a.Livro)
                            .Where(a => a.Id == z.Id).First();
                        });

                        x.CartaoCreditoPedido.ForEach(a =>
                        {
                            a.Pedido = null;
                            a = db.CartaoCreditoPedido
                            .Include(b => b.CartaoCredito)
                            .Include(b => b.Pedido)
                            .Where(b => b.Id == a.Id).First();
                        });

                        x.Cliente.CartaoCredito = null;
                        x.CartaoCreditoPedido.ForEach(c => c.CartaoCredito.CartaoCreditoPedido = null);

                        mensagem.Dados.Add(x);
                    });
                }
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

        public MensagemModel ConsultarId(EntidadeDominio Objeto)
        {
            var Pedido = (PedidoModel)Objeto;

            using (var db = new ToCBooksContext())
            {
                db.Pedido
               .Include(x => x.Cliente)
               .Include(x => x.EnderecoEntrega)
               .Include(x => x.ItensPedido)
               .Include(x => x.CartaoCreditoPedido)
               .Where(x => x.Id == Pedido.Id)
               .ToList()
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

                   x.ItensPedido.ForEach(z =>
                   {
                       z.Pedido = null;
                       z = db.ItensPedidos
                       .Include(a => a.Pedido)
                       .Include(a => a.Livro)
                       .Where(a => a.Id == z.Id).First();
                   });

                   x.CartaoCreditoPedido.ForEach(a =>
                   {
                       a.Pedido = null;
                       a = db.CartaoCreditoPedido
                       .Include(b => b.CartaoCredito)
                       .Include(b => b.Pedido)
                       .Where(b => b.Id == a.Id).First();
                   });

                   x.Cliente.CartaoCredito = null;
                   x.CartaoCreditoPedido.ForEach(c => c.CartaoCredito.CartaoCreditoPedido = null);

                   mensagem.Dados.Add(x);
               });

                return mensagem;
            }
        }
    }
}
