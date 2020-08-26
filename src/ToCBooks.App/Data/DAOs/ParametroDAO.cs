using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class ParametroDAO : IDAO
    {
        public Task<MensagemModel> Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MensagemModel>> Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
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
            MensagemModel Mensagem = new MensagemModel();

            Mensagem.Codigo = 1;
            Mensagem.Dados = null;

            return Mensagem;
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();

            
            using (var db = new ToCBooksContext())
            {
                db.Parametros.Where(x => x.StatusAtual == EntidadeDominio.Status.Ativo).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<MensagemModel> Editar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<MensagemModel> Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        MensagemModel IDAO.Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MensagemModel> IDAO.Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        MensagemModel IDAO.Editar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        MensagemModel IDAO.Excluir(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
