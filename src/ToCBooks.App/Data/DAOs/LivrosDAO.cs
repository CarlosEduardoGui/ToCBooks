using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.Data.DAOs
{
    public class LivrosDAO : ToCBooksContext, IDAO
    {
        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                LivrosModel Livro = db.Find<LivrosModel>(Objeto.Id);
                Livro.StatusAtual = ETipoStatus.Ativo;
                Livro.Justificativa = Objeto.Justificativa;
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Livro Ativado...";

            return Mensagem;
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                db.Find<EntidadeDominio>(Objeto.Id);
            }


            throw new NotImplementedException();
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                db.Livro.Where(predicate.Compile()).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            LivrosModel Livro = (LivrosModel)Objeto;

            using (var db = new ToCBooksContext())
            {
                Livro.Precificacao = db.Find<Parametro>(Livro.Precificacao.Id);

                db.Livro.Add(Livro);
                db.SaveChanges();
            }
            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = 0,
                Resposta = "Livro Foi Cadastrado Com Sucesso..."
            };

            return Mensagem;
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                var ObjetoPersistido = db.Find<LivrosModel>(Objeto.Id);
                if (ObjetoPersistido != null)
                {
                    Mensagem.Dados.Add(ObjetoPersistido);

                }
                else
                {
                    db.Livro.Where(x => x.StatusAtual == ETipoStatus.Ativo).ToList().ForEach(x => Mensagem.Dados.Add(x));
                }
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
                LivrosModel Livro = db.Find<LivrosModel>(Objeto.Id);
                Livro.StatusAtual = ETipoStatus.Inativo;
                Livro.Justificativa = Objeto.Justificativa;
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
