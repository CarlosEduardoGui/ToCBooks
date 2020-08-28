using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Validadores;
using ToCBooks.App.Data.DAOs;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Patterns.Interfaces;

namespace ToCBooks.Data.Business.Patterns
{
    public class Fachada : IFachada
    {
        private Dictionary<string, IDAO> mapDao = new Dictionary<string, IDAO>();
        private Dictionary<string, List<IStrategy>> mapValidadores = new Dictionary<string, List<IStrategy>>();

        public Fachada()
        {
            mapDao.Add("LivrosModel", new LivrosDAO());
            mapDao.Add("ClienteModel", new ClienteDAO());
            mapDao.Add("Parametro", new ParametroDAO());

            List<IStrategy> ValidadoresLivro = new List<IStrategy> 
            { 
                new ValidadorLivro()
            };

            List<IStrategy> ValidadoresParametro = new List<IStrategy>
            {
                new ValidadorParametro()
            };

            mapValidadores.Add("LivrosModel", ValidadoresLivro);
            mapValidadores.Add("Parametro", ValidadoresParametro);
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            try
            {
                foreach (var Validador in mapValidadores[Objeto.GetType().Name])
                    Validador.Validar(Objeto);

                var respostaDao = mapDao[Objeto.GetType().Name].Cadastrar(Objeto);

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

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            return mapDao[Objeto.GetType().Name].Consultar(Objeto);
        }

        public MensagemModel Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
