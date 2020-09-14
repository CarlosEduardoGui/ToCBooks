using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class ParametroDAO : IDAO
    {
        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                Parametro Parametro = (Parametro)Objeto;
                db.Parametros.Update(Parametro);
                db.SaveChanges();
            }

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 1,
                Dados = null
            };

            return Mensagem;
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            var Despachante = (Despachante)Objeto;

            using (var db = new ToCBooksContext())
            {
                db.Add(Despachante.Entidade);
                db.SaveChanges();
            }

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 1,
                Dados = null
            };

            return Mensagem;
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                var ObjetoPersistido = db.Find<Parametro>(Objeto.Id);
                if (ObjetoPersistido != null)
                    Mensagem.Dados.Add(ObjetoPersistido);
                else
                    db.Parametros.Where(x => x.StatusAtual == ETipoStatus.Ativo && x.Tipo == Parametro.TipoParametro.GrupoPrecificacao).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Dados.OrderBy(x => x.Id);
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

        public MensagemModel Editar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Excluir(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                db.Remove(Objeto);
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Excluidos Com Sucesso ...";

            return Mensagem;
        }

    }
}
