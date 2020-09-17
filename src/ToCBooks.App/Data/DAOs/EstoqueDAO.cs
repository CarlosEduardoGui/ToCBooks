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
    public class EstoqueDAO : IDAO 
    {
        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            var ItemEstoque = (ItemEstoque)Objeto;


            using (var db = new ToCBooksContext())
            {
                ItemEstoque.Livro = db.Livro.Where(x => x.Id == ItemEstoque.Livro.Id).FirstOrDefault();
                db.Estoque.Update(ItemEstoque);
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Item Atualizado Com Suscesso...";

            return Mensagem;
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            var ItemEstoque = (ItemEstoque)Objeto;


            using (var db = new ToCBooksContext())
            {
                if(db.Estoque.Where(x => x.Livro.Id == ItemEstoque.Livro.Id && x.Qtde > 0).Count() > 0)
                {
                    ItemEstoque.Id = db.Estoque.Where(x => x.Livro.Id == ItemEstoque.Livro.Id && x.Qtde > 0).Select(x => x.Id).FirstOrDefault();
                    return Atualizar(ItemEstoque);
                }

                ItemEstoque.Livro = db.Livro.Where(x => x.Id == ItemEstoque.Livro.Id).FirstOrDefault();
                db.Estoque.Add(ItemEstoque);
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Item Cadastrado Com Suscesso...";

            return Mensagem;
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            var Despachante = (Despachante)Objeto;
            var ItemEstoque = (ItemEstoque)Despachante.Entidade;

            using (var db = new ToCBooksContext())
            {
                if (ItemEstoque.Qtde > 0)
                    db.Estoque.Where(x => x.Livro.Id == ItemEstoque.Livro.Id && x.Qtde == ItemEstoque.Qtde).ToList().ForEach(x => Mensagem.Dados.Add(x));
                else
                    db.Estoque.Where(x => x.Livro.Id == ItemEstoque.Livro.Id).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso...";

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
            throw new NotImplementedException();
        }
    }
}
