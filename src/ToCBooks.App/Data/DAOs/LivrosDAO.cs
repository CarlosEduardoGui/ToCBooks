using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class LivrosDAO : ToCBooksContext, IDAO
    {

        public virtual async Task<MensagemModel> Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                await db.FindAsync<EntidadeDominio>(Objeto.Id);
            }


            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MensagemModel>> Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<MensagemModel> Cadastrar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                db.Add(Objeto);
                await db.SaveChangesAsync();
            }
            MensagemModel Mensagem = new MensagemModel();

            Mensagem.Codigo = 1;
            Mensagem.Dados = null;

            return Mensagem;
        }

        public async Task<MensagemModel> Consultar(EntidadeDominio Objeto)
        {

            throw new NotImplementedException();
        }

        public async Task<MensagemModel> Editar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<MensagemModel> Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
