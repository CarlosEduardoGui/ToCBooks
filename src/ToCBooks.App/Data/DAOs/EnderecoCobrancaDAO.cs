using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class EnderecoCobrancaDAO : IDAO
    {
        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Endereco = (EnderecoCobrancaModel)Objeto;
                db.EnderecoCobranca.Update(Endereco);
                db.SaveChanges();
            }

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = ETipoCodigo.Errado,
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
            using (var db = new ToCBooksContext())
            {
                db.Add(Objeto);
                db.SaveChanges();
            }

            MensagemModel Mensagem = new MensagemModel
            {
                Codigo = ETipoCodigo.Correto,
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
            var Despachante = (Despachante)Objeto;

            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                var ObjetoPersistido = db.EnderecoCobranca
                    .Include(x => x.Cidade)
                    .Include(x => x.Cidade.Estado)
                    .Include(x => x.Cidade.Estado.Pais)
                    .Where(x => x.Id == Despachante.Entidade.Id).ToList().FirstOrDefault();
                if (ObjetoPersistido != null)
                    Mensagem.Dados.Add(ObjetoPersistido);
                else
                    db.EnderecoCobranca
                        .Include(x => x.Cidade)
                        .Include(x => x.Cidade.Estado)
                        .Include(x => x.Cidade.Estado.Pais)
                        .Where(x => x.StatusAtual == ETipoStatus.Ativo && x.ClienteId == Despachante.Login.ClienteId).ToList().ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Dados.OrderBy(x => x.Id);
            Mensagem.Codigo = ETipoCodigo.Correto;
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
                if (db.EnderecoCobranca.Where(x => x.StatusAtual == ETipoStatus.Ativo).Count() == 1)
                    throw new Exception("O Sistema não permite a deleção de todos os endereços...");

                db.EnderecoCobranca.Remove((EnderecoCobrancaModel)Objeto);
                db.SaveChanges();
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Dados Excluidos Com Sucesso ...";

            return Mensagem;
        }
    }
}
