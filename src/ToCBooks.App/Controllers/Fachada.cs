using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.DAOs;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;
using ToCBooks.App.Validadores;

namespace ToCBooks.App.Controllers
{
    public class Fachada : IFachada
    {
        private Dictionary<string, IDao> mapDao = new Dictionary<string, IDao>();
        private Dictionary<string, List<IStrategy>> mapValidadores = new Dictionary<string, List<IStrategy>>();

        public Fachada()
        {
            mapDao.Add("Livro", new LivroDAO());

            List<IStrategy> ValidadoresLivro = new List<IStrategy> 
            { 
                new ValidadorLivro()
            };

            mapValidadores.Add("Livro", ValidadoresLivro);
        }
        public Mensagem Atualizar(Entidade Objeto)
        {
            throw new NotImplementedException();
        }

        public Mensagem Cadastrar(Entidade Objeto)
        {
            Mensagem Mensagem = new Mensagem();
            try
            {
                foreach (var Validador in mapValidadores[Objeto.GetType().Name])
                    Validador.Validar(Objeto);

                return mapDao[Objeto.GetType().Name].Cadastrar(Objeto);
            } catch(Exception Error)
            {
                Mensagem.Codigo = 0;
                Mensagem.Resposta = Error.Message;
                Mensagem.Dados = null;
            }

            return Mensagem;
        }

        public Mensagem Consultar(Entidade Objeto)
        {
            return mapDao[Objeto.GetType().Name].Consultar(Objeto);
        }

        public Mensagem Excluir(Entidade Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
