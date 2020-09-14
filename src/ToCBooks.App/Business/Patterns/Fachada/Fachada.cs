using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Validadores;
using ToCBooks.App.Data.DAOs;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Modeladores;

namespace ToCBooks.Data.Business.Patterns
{
    public class Fachada : IFachada
    {
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

            mapValidadores.Add("LivrosModel", ValidadoresLivro);
            mapValidadores.Add("Parametro", ValidadoresParametro);
            mapValidadores.Add("ClienteModel", ValidadoresCliente);
            mapValidadores.Add("LoginModel", ValidadoresLogin);
            mapValidadores.Add("CartaoCreditoModel", ValidadoresCartaoCredito);

            mapValidadores.Add("EnderecoCobrancaModel", ValidadoresEnderecoCobranca);
            mapValidadores.Add("EnderecoEntregaModel", ValidadoresEnderecoEntrega);
            mapExpressoes.Add("LivrosModel", new BuscaLivros());
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
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
                Mensagem.Codigo = 0;
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
                Mensagem.Codigo = 0;
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
                Mensagem.Codigo = 0;
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
            } catch(Exception error)
            {
                Mensagem = new MensagemModel();
                Mensagem.Codigo = 1;
                Mensagem.Resposta = error.Message;

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
                Mensagem.Codigo = 0;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }
    }
}
