using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.Data.DAOs
{
    public class LivrosDAO : ToCBooksContext, IDAO
    {

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                db.Find<EntidadeDominio>(Objeto.Id);
            }


            throw new NotImplementedException();
        }

        public IEnumerable<MensagemModel> Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                db.Add(Objeto);
                db.SaveChanges();
            }
            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 1,
                Dados = null
            };

            return Mensagem;
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                db.Livro.Where(x => x.StatusAtual == EntidadeDominio.Status.Ativo).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                LivrosModel Livro = db.Livro.Where(x => x.Id == Objeto.Id).First();
                Livro.StatusAtual = EntidadeDominio.Status.Inativo;
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Livro Desativado...";

            return Mensagem;
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
