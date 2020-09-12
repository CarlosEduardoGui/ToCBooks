using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;

namespace ToCBooks.App.Data.DAOs
{
    public class ClienteDAO : IDAO
    {
        private int result;
        private MensagemModel mensagem = new MensagemModel();

        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Cliente = (ClienteModel)Objeto;

                db.Cliente.Update(Cliente);
                result = db.SaveChanges();

                if (result == 1)
                {
                    mensagem.Codigo = 0;
                    mensagem.Resposta = "Cliente atualizado!";

                    return mensagem;
                }

                mensagem.Codigo = 1;
                mensagem.Resposta = "Erro ao atualizar Cliente";

                return mensagem;
            }
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Cliente = (ClienteModel)Objeto;
                db.Cliente.Add(Cliente);
                result = db.SaveChanges();

                if (result == 1)
                {
                    mensagem.Codigo = 1;
                    mensagem.Resposta = "Cliente foi cadastrado com sucesso";

                    return mensagem;
                }

                mensagem.Codigo = 2;
                mensagem.Resposta = "Erro ao cadastrar Cliente";

                return mensagem;
            }
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Cliente = (ClienteModel)Objeto;

                var ObjetoPersistido = db.Cliente.Find(Cliente.Id);
                if (ObjetoPersistido != null)
                    mensagem.Dados.Add(ObjetoPersistido);
                else
                    db.Cliente.Where(x => x.StatusAtual == ETipoStatus.Ativo).ToList().ForEach(x => mensagem.Dados.Add(x));

                mensagem.Codigo = 0;
                mensagem.Resposta = "Cliente consultado com sucesso";

                return mensagem;
            }
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
