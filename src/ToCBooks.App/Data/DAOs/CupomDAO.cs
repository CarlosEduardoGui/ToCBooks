using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class CupomDAO : IDAO
    {
        private MensagemModel mensagem = new MensagemModel();
        private int resultado;

        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var cupom = (CupomModel)Objeto;

                db.Cupom.Add(cupom);
                resultado = db.SaveChanges();

                if (resultado == 1)
                {
                    mensagem.Codigo = ETipoCodigo.Correto;
                    mensagem.Resposta = "Cupom cadastrado com sucesso";
                }

                mensagem.Codigo = ETipoCodigo.Errado;
                mensagem.Resposta = "Erro ao cadastrar cupom";
                return mensagem;
            }
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Despachante = (Despachante)Objeto;
                var cupom = (CupomModel)Despachante.Entidade;

                var ObjetoPersistido = db.Cupom
                    .Where(x => x.Nome == cupom.Nome && x.StatusAtual == ETipoStatus.Ativo).ToList().FirstOrDefault();

                if (ObjetoPersistido != null)
                    mensagem.Dados.Add(ObjetoPersistido);

                mensagem.Codigo = ETipoCodigo.Correto;
                mensagem.Resposta = "Cupom consultado com sucesso";

                return mensagem;
            }
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Cupom = (CupomModel)Objeto;

                var result = db.Find<CupomModel>(Cupom.Id);
                result.StatusAtual = ETipoStatus.Inativo;
                db.SaveChanges();
            }

            mensagem.Codigo = ETipoCodigo.Correto;
            mensagem.Resposta = "Cupom Desativado...";

            return mensagem;
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
