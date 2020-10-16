using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Business.Validadores;
using ToCBooks.App.Data.DAOs;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Modeladores;

namespace ToCBooks.Data.Business.Patterns
{
    public class Fachada : IFachada
    {
        public HttpContext SessionLink { get; set; }
        private Dictionary<string, IDAO> mapDao = new Dictionary<string, IDAO>();
        private Dictionary<string, List<IStrategy>> mapValidadores = new Dictionary<string, List<IStrategy>>();
        private Dictionary<string, IBusca> mapExpressoes = new Dictionary<string, IBusca>();

        public Fachada()
        {
            mapDao.Add("LivrosModel", new LivrosDAO());
            mapDao.Add("ClienteModel", new ClienteDAO());
            mapDao.Add("Parametro", new ParametroDAO());
            mapDao.Add("LoginModel", new LoginDAO());
            mapDao.Add("CartaoCreditoModel", new CartaoCreditoDAO());
            mapDao.Add("EnderecoCobrancaModel", new EnderecoCobrancaDAO());
            mapDao.Add("EnderecoEntregaModel", new EnderecoEntregaDAO());
            mapDao.Add("ItemEstoque", new EstoqueDAO());
            mapDao.Add("CupomModel", new CupomDAO());
            mapDao.Add("PedidoModel", new PedidoDAO());

            #region Validadores Livro

            List<IStrategy> ValidadoresLivro = new List<IStrategy>
            {
                new ValidadorLivro()
            };

            #endregion

            #region Validadores Cliente

            List<IStrategy> ValidadoresCliente = new List<IStrategy>
            {
                new ValidadorCliente(),
            };

            #endregion

            #region Validadores Paramatro

            List<IStrategy> ValidadoresParametro = new List<IStrategy>
            {
                new ValidadorParametro()
            };

            #endregion

            #region Validadores EnderecoCobranca

            List<IStrategy> ValidadoresEnderecoCobranca = new List<IStrategy>
            {
                new ValidadorEnderecoCobranca()
            };

            #endregion

            #region Validadores EnderecoCobranca

            List<IStrategy> ValidadoresEnderecoEntrega = new List<IStrategy>
            {
                new ValidadorEnderecoEntrega()
            };

            #endregion

            #region Validadores Login

            var ValidadoresLogin = new List<IStrategy>
            {
                new ValidadorLogin()
            };

            #endregion

            #region Validadores Cartão de Crédito

            var ValidadoresCartaoCredito = new List<IStrategy>
            {
                new ValidadorCartaoCredito()
            };

            #endregion

            #region Validadores de Estoque

            var ValidadoresEstoque = new List<IStrategy>
            {
                new ValidadorEstoque()
            };

            #endregion

            #region Validadores Cupom

            var ValidadoresCupom = new List<IStrategy>
            {
                new ValidadorCupom()
            };

            #endregion

            #region Validadores de Status de Troca

            var ValidadorStatusTroca = new List<IStrategy>
            {
                new ValidadorTrocaStatusAprovado()
            };


            var ValidadorStatusEmTransito = new List<IStrategy>
            {
                new ValidadorTrocaStatusEmTransito()
            };


            var ValidadorStatusEntregue = new List<IStrategy>
            {
                new ValidadorTrocaStatusEntregue()
            };


            var ValidadorStatusEmTroca = new List<IStrategy>
            {
                new ValidadorTrocaStatusEmTroca()
            };


            var ValidadorStatusTrocaAutorizada = new List<IStrategy>
            {
                new ValidadorTrocaStatusTrocaAutorizada()
            };


            var ValidadorStatusTrocado = new List<IStrategy>
            {
                new ValidadorTrocaStatusTrocado()
            };

            #endregion

            mapValidadores.Add("LivrosModel", ValidadoresLivro);
            mapValidadores.Add("Parametro", ValidadoresParametro);
            mapValidadores.Add("ClienteModel", ValidadoresCliente);
            mapValidadores.Add("LoginModel", ValidadoresLogin);
            mapValidadores.Add("CartaoCreditoModel", ValidadoresCartaoCredito);
            mapValidadores.Add("EnderecoCobrancaModel", ValidadoresEnderecoCobranca);
            mapValidadores.Add("EnderecoEntregaModel", ValidadoresEnderecoEntrega);
            mapValidadores.Add("ItemEstoque", ValidadoresEstoque);
            mapValidadores.Add("CupomModel", ValidadoresCupom);
            mapValidadores.Add(ETipoStatus.Aprovada.ToString(), ValidadorStatusTroca);
            mapValidadores.Add(ETipoStatus.EmTransito.ToString(), ValidadorStatusEmTransito);
            mapValidadores.Add(ETipoStatus.Entregue.ToString(), ValidadorStatusEntregue);
            mapValidadores.Add(ETipoStatus.EmTroca.ToString(), ValidadorStatusEmTroca);
            mapValidadores.Add(ETipoStatus.TrocaAutorizada.ToString(), ValidadorStatusTrocaAutorizada);
            mapValidadores.Add(ETipoStatus.Trocado.ToString(), ValidadorStatusTrocado);

            mapExpressoes.Add("LivrosModel", new BuscaLivros());
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            MensagemModel Mensagem = new MensagemModel();
            try
            {
                foreach (var Validador in mapValidadores[Objeto.GetType().Name])
                    Validador.Validar(Despachante.Entidade);

                mapDao[Objeto.GetType().Name].Atualizar(Objeto);

                Mensagem.Codigo = 0;
                Mensagem.Resposta = "Troca de Status Concluida...";
                Mensagem.Dados = null;

                return Mensagem;
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            MensagemModel Mensagem = new MensagemModel();
            try
            {
                foreach (var Validador in mapValidadores[Objeto.GetType().Name])
                    Validador.Validar(Despachante.Entidade);

                if (mapDao[Objeto.GetType().Name].Consultar(Despachante).Dados.Select(x => x.Id).Contains(Objeto.Id))
                    mapDao[Objeto.GetType().Name].Atualizar(Objeto);
                else
                    mapDao[Objeto.GetType().Name].Cadastrar(Objeto);

                Mensagem.Codigo = 0;
                Mensagem.Resposta = "Dados Cadastrados...";
                Mensagem.Dados = null;

                return Mensagem;
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public MensagemModel DesativarRegistro(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            MensagemModel Mensagem = new MensagemModel();
            try
            {
                return Objeto.Id == null
                    ? throw new Exception("Objeto inválido para Desativação...")
                    : mapDao[Objeto.GetType().Name].Desativar(Objeto);
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public MensagemModel AtivarRegistro(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            MensagemModel Mensagem = new MensagemModel();
            try
            {
                return Objeto.Id == null
                    ? throw new Exception("Objeto inválido para Ativação...")
                    : mapDao[Objeto.GetType().Name].Ativar(Objeto);
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            return mapDao[Objeto.GetType().Name].Consultar(Despachante);
        }

        public MensagemModel Excluir(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            MensagemModel Mensagem;
            try
            {
                return mapDao[Objeto.GetType().Name].Excluir(Objeto);
            }
            catch (Exception error)
            {
                Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = error.Message
                };

                return Mensagem;
            }

        }

        public MensagemModel Buscar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            Objeto = Despachante.Entidade;

            var NomeObjeto = Objeto.GetType().Name;

            return mapDao[NomeObjeto].ConsultaCustomizada(Objeto);
        }

        public MensagemModel Login(EntidadeDominio Objeto)
        {
            var Mensagem = new MensagemModel();
            try
            {
                foreach (var Validadores in mapValidadores[Objeto.GetType().Name])
                    Validadores.Validar(Objeto);

                Mensagem = mapDao[Objeto.GetType().Name].Consultar(Objeto);

                return Mensagem;
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public MensagemModel AtualizarPreco(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;
            return new LivrosDAO().AtualizarPreco(Despachante.Entidade);
        }

        public MensagemModel AdicionarItemCarrinho(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            try
            {
                var Despachante = (Despachante)Objeto;

                new ValidadorEntradaCarrinho().Validar(Despachante);

                var ItemEstoque = (ItemEstoque)Despachante.Entidade;
                ItemEstoque.DataCadastro = DateTime.Now;
                ItemEstoque.Livro = (LivrosModel)new LivrosDAO().Consultar(ItemEstoque.Livro).Dados.First();

                bool FlagItemExistente = false;
                Carrinho Carrinho = new Carrinho();
                if (SessionLink.Session.GetString("Carrinho") != null)
                {
                    Carrinho = JsonConvert.DeserializeObject<Carrinho>(SessionLink.Session.GetString("Carrinho"));

                    foreach (var Item in Carrinho.Itens)
                        if (Item != null)
                        {
                            if (Item.Livro.Id == ItemEstoque.Livro.Id)
                            {
                                Item.Qtde += ItemEstoque.Qtde;
                                FlagItemExistente = true;
                            }
                        }
                }

                if (!FlagItemExistente)
                    Carrinho.Itens.Add((ItemEstoque)Despachante.Entidade);

                SessionLink.Session.SetString("Carrinho", JsonConvert.SerializeObject(Carrinho));

                Mensagem.Codigo = ETipoCodigo.Correto;
                Mensagem.Resposta = "Item Adicionado Com sucesso !!!";
            }
            catch (Exception error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = error.Message;
            }

            return Mensagem;
        }

        public MensagemModel ConsultarCarrinho()
        {
            MensagemModel Mensagem = new MensagemModel();

            if (SessionLink.Session.GetString("Carrinho") == null)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = "Carrinho não Encotrado para o Usuário Atual...";
            }
            else
            {
                Mensagem.Codigo = ETipoCodigo.Correto;
                Mensagem.Resposta = "Carrinho Encontrado...";
                Mensagem.Dados.Add(JsonConvert.DeserializeObject<Carrinho>(SessionLink.Session.GetString("Carrinho")));
            }

            return Mensagem;
        }

        public MensagemModel ExcluirItemCarrinho(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            var Despachante = (Despachante)Objeto;
            var ItemEstoque = Despachante.Entidade;
            var Carrinho = JsonConvert.DeserializeObject<Carrinho>(SessionLink.Session.GetString("Carrinho"));
            for (var i = 0; i < Carrinho.Itens.Count; i++)
                if (Carrinho.Itens[i] != null)
                    if (Carrinho.Itens[i].Id == ItemEstoque.Id)
                        Carrinho.Itens[i] = null;

            SessionLink.Session.SetString("Carrinho", JsonConvert.SerializeObject(Carrinho));

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Item Excluido com Sucesso !!!";

            return Mensagem;
        }

        public MensagemModel AtualizarCarrinho(Despachante Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            try
            {
                var CarrinhoRecebido = (Carrinho)Objeto.Entidade;

                if (SessionLink.Session.GetString("Carrinho") == null)
                    throw new Exception("Carrinho Não Encontrado...");

                var CarrinhoAtual = JsonConvert.DeserializeObject<Carrinho>(SessionLink.Session.GetString("Carrinho"));

                if (CarrinhoAtual.Itens.Count <= 0)
                    throw new Exception("Nenhum Item no Carrinho...");

                foreach (var Item in CarrinhoAtual.Itens)
                {
                    if (Item != null)
                    {
                        var ItemRecebido = CarrinhoRecebido.Itens.Find(x => x.Livro.Id == Item.Livro.Id);

                        if (ItemRecebido.Qtde != Item.Qtde)
                            Item.Qtde = ItemRecebido.Qtde;

                        Despachante Despachante = new Despachante
                        {
                            Entidade = Item
                        };

                        new ValidadorEntradaCarrinho().Validar(Despachante);
                    }
                }

                SessionLink.Session.SetString("Carrinho", JsonConvert.SerializeObject(CarrinhoAtual));

                if (SessionLink.Session.GetString("ClienteID") == null)
                    throw new Exception("Necessário fazer Login para Continuar...");

            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;

                return Mensagem;
            }


            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Carrinho Atualizado com Sucesso !!!";

            return Mensagem;
        }

        public MensagemModel ConfirmarCompra(Despachante Despachante)
        {
            MensagemModel Mensagem = new MensagemModel();

            try
            {
                var Pedido = (PedidoModel)Despachante.Entidade;
                var CarrinhoAtual = JsonConvert.DeserializeObject<Carrinho>(SessionLink.Session.GetString("Carrinho"));
                CarrinhoAtual.Itens.ForEach(x =>
                {
                    if (x != null)
                    {
                        var ItemPedido = new ItemPedido
                        {
                            Livro = x.Livro,
                            Qtde = x.Qtde,
                            Pedido = Pedido
                        };

                        Pedido.ItensPedido.Add(ItemPedido);
                    }
                });
                var ClienteTemp = new ClienteModel
                {
                    Id = Guid.Parse(SessionLink.Session.GetString("ClienteID"))
                };
                Despachante.Entidade = ClienteTemp;
                Pedido.Cliente = (ClienteModel)new ClienteDAO().Consultar(Despachante).Dados.FirstOrDefault();
                Pedido.EnderecoEntrega = Pedido.Cliente.EnderecoEntrega.Find(x => x.Id == Pedido.EnderecoEntrega.Id);

                for (var i = 0; i < Pedido.ItensPedido.Count; i++)
                    Pedido.ItensPedido[i].Livro.Precificacao = null;

                for (var i = 0; i < Pedido.CartoesCredito.Count; i++)
                    Pedido.CartoesCredito[i] = Pedido.Cliente.CartaoCredito.Find(x => x.Id == Pedido.CartoesCredito[i].Id);

                Pedido.ItensPedido.ForEach(x => Pedido.TotalPedido += (x.Livro.Preco * x.Qtde));

                if (Pedido.CupomDesconto != null)
                {
                    Pedido.TotalPedido = (Pedido.TotalPedido - (Pedido.TotalPedido * (Pedido.CupomDesconto.Desconto / 100)));
                    Pedido.CupomDesconto.StatusAtual = ETipoStatus.Inativo;
                }


                if ((Pedido.TotalPedido / Pedido.CartoesCredito.Count) <= 10)
                    throw new Exception("O Valor da Compra dividido entre os cartões é menor do que R$10...");

                Pedido.StatusAtual = ETipoStatus.EmProcessamento;

                Pedido.CartoesCredito.ForEach(x =>
                {
                    var RelCartaoPedido = new CartaoCreditoPedido
                    {
                        CartaoCreditoID = x.Id,
                        PedidoId = Pedido.Id
                    };

                    Pedido.CartaoCreditoPedido.Add(RelCartaoPedido);
                });

                CarrinhoAtual.Itens.Clear();
                SessionLink.Session.SetString("Carrinho", JsonConvert.SerializeObject(CarrinhoAtual));

                Mensagem = new PedidoDAO().Cadastrar(Pedido);
                Pedido.Cliente = null;
                Pedido.CartoesCredito = null;
                Pedido.CartaoCreditoPedido = null;
                Pedido.CupomDesconto = null;
                Pedido.EnderecoEntrega = null;
                Pedido.ItensPedido = null;

                Mensagem.Dados.Add(Pedido);
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = ETipoCodigo.Errado;
                Mensagem.Resposta = Error.Message;
            }

            return Mensagem;
        }

        public MensagemModel ProcessarPagamentos()
        {
            var ListaPedidos = new PedidoDAO().ConsultarPedidosPendentes().Dados;
            ValidadorPedidosPendentes Validador = new ValidadorPedidosPendentes();
            PedidoDAO PedidoDAO = new PedidoDAO();
            EstoqueDAO EstoqueDAO = new EstoqueDAO();

            ListaPedidos.ForEach(x =>
            {
                try
                {
                    var Pedido = (PedidoModel)x;

                    Validador.Validar(Pedido);
                    Pedido.StatusAtual = ETipoStatus.Aprovada;

                    Pedido.ItensPedido.ForEach(y =>
                    {
                        ItemEstoque Item = new ItemEstoque
                        {
                            Livro = y.Livro,
                            Qtde = 0
                        };

                        var Despachante = new Despachante();
                        Despachante.Entidade = Item;
                        ItemEstoque ItemAtual = (ItemEstoque)EstoqueDAO.Consultar(Despachante).Dados.FirstOrDefault();
                        ItemAtual.Qtde -= y.Qtde;
                        ItemAtual.Livro = Item.Livro;

                        EstoqueDAO.Atualizar(ItemAtual);
                    });

                    PedidoDAO.Atualizar(Pedido);
                }
                catch (Exception Error)
                {
                    x.StatusAtual = ETipoStatus.Reprovada;
                    PedidoDAO.Atualizar(x);
                }
            });

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = ETipoCodigo.Correto,
                Resposta = "Pedidos Processados com sucesso !!!"
            };

            return Mensagem;
        }


        public MensagemModel TrocaStatusProdutoAtivo(EntidadeDominio Objeto) //Troca para Em Trânsito
        {
            try
            {
                var Despachante = (Despachante)Objeto;
                Objeto = Despachante.Entidade;

                var resultado = new PedidoDAO().ConsultarId(Objeto);
                Objeto.StatusAtual = resultado.Dados[0].StatusAtual;

                foreach (var Validador in mapValidadores[resultado.Dados[0].StatusAtual.ToString()])
                    Validador.Validar(Objeto);


                resultado.Dados[0].StatusAtual = ETipoStatus.EmTransito;

                return mapDao[Objeto.GetType().Name].Atualizar(resultado.Dados[0]);
            }
            catch (Exception e)
            {
                MensagemModel Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = e.Message
                };

                return Mensagem;
            }
        }


        public MensagemModel TrocaStatusProdutoEmTransito(EntidadeDominio Objeto) //Troca para Entregue
        {
            try
            {
                var Despachante = (Despachante)Objeto;
                Objeto = Despachante.Entidade;

                var resultado = new PedidoDAO().ConsultarId(Objeto);
                Objeto.StatusAtual = resultado.Dados[0].StatusAtual;

                foreach (var Validador in mapValidadores[resultado.Dados[0].StatusAtual.ToString()])
                    Validador.Validar(Objeto);


                resultado.Dados[0].StatusAtual = ETipoStatus.Entregue;

                return mapDao[Objeto.GetType().Name].Atualizar(resultado.Dados[0]);
            }
            catch (Exception e)
            {
                MensagemModel Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = e.Message
                };

                return Mensagem;
            }
        }

        public MensagemModel TrocaStatusProdutoEntregue(EntidadeDominio Objeto) //Troca para Em EmTroca
        {
            try
            {
                var Despachante = (Despachante)Objeto;
                Objeto = Despachante.Entidade;

                var resultado = new PedidoDAO().ConsultarId(Objeto);
                Objeto.StatusAtual = resultado.Dados[0].StatusAtual;

                foreach (var Validador in mapValidadores[resultado.Dados[0].StatusAtual.ToString()])
                    Validador.Validar(Objeto);


                resultado.Dados[0].StatusAtual = ETipoStatus.EmTroca;

                return mapDao[Objeto.GetType().Name].Atualizar(resultado.Dados[0]);
            }
            catch (Exception e)
            {
                MensagemModel Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = e.Message
                };

                return Mensagem;
            }
        }

        public MensagemModel TrocaStatusProdutoEmTroca(EntidadeDominio Objeto) //Troca para Em TrocaAutorizada
        {
            try
            {
                var Despachante = (Despachante)Objeto;
                Objeto = Despachante.Entidade;

                var resultado = new PedidoDAO().ConsultarId(Objeto);
                Objeto.StatusAtual = resultado.Dados[0].StatusAtual;

                foreach (var Validador in mapValidadores[resultado.Dados[0].StatusAtual.ToString()])
                    Validador.Validar(Objeto);


                resultado.Dados[0].StatusAtual = ETipoStatus.TrocaAutorizada;

                return mapDao[Objeto.GetType().Name].Atualizar(resultado.Dados[0]);
            }
            catch (Exception e)
            {
                MensagemModel Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = e.Message
                };

                return Mensagem;
            }
        }



        public MensagemModel TrocaStatusTrocaAutorizada(EntidadeDominio Objeto) //Troca para Em Trânsito
        {
            try
            {
                var Despachante = (Despachante)Objeto;
                Objeto = Despachante.Entidade;

                var resultado = new PedidoDAO().ConsultarId(Objeto);
                Objeto.StatusAtual = resultado.Dados[0].StatusAtual;

                foreach (var Validador in mapValidadores[resultado.Dados[0].StatusAtual.ToString()])
                    Validador.Validar(Objeto);


                resultado.Dados[0].StatusAtual = ETipoStatus.Trocado;

                return mapDao[Objeto.GetType().Name].Atualizar(resultado.Dados[0]);
            }
            catch (Exception e)
            {
                MensagemModel Mensagem = new MensagemModel
                {
                    Codigo = ETipoCodigo.Errado,
                    Resposta = e.Message
                };

                return Mensagem;
            }
        }
    }
}
