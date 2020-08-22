using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToCBooks.App.Patterns.Interfaces;
using ToCBooks.Business.Interfaces;
using ToCBooks.Business.Patterns.Validadores;
using ToCBooks.Data.DAOs;
using ToCBooks.Data.Interfaces;
using ToCBooks.Data.Models;

namespace ToCBooks.Business.Patterns
{
    public class Fachada : IFachada
    {
        private Dictionary<string, IDAO> mapDao = new Dictionary<string, IDAO>();
        private Dictionary<string, List<IStrategy>> mapValidadores = new Dictionary<string, List<IStrategy>>();

        public Fachada()
        {
            mapDao.Add("LivrosModel", new LivrosDAO());

            List<IStrategy> ValidadoresLivro = new List<IStrategy> 
            { 
                new ValidadorLivro()
            };

            mapValidadores.Add("LivrosViewModel", ValidadoresLivro);
        }

        public async Task<MensagemModel> Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<MensagemModel> Cadastrar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            try
            {
                foreach (var Validador in mapValidadores[Objeto.GetType().Name])
                    Validador.Validar(Objeto);

                return await mapDao[Objeto.GetType().Name].Cadastrar(Objeto);
            }
            catch (Exception Error)
            {
                Mensagem.Codigo = 0;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public async Task<MensagemModel> Consultar(EntidadeDominio Objeto)
        {
            return await mapDao[Objeto.GetType().Name].Consultar(Objeto);
        }

        public async Task<MensagemModel> Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
