using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;
using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Data.DAOs
{
    public class LoginDAO : IDAO
    {
        private MensagemModel mensagem = new MensagemModel();
        private int result;

        public MensagemModel Ativar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Atualizar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Login = (LoginModel)Objeto;

                var idLogin = db.Login.Where(x => x.Email == Login.Email).Select(x => x.Id).FirstOrDefault();

                Login.Id = idLogin;

                db.Login.Update(Login);
                result = db.SaveChanges();

                if (result == 1)
                {
                    mensagem.Codigo = ETipoCodigo.Correto;
                    mensagem.Resposta = "Senha alterada";
                    return mensagem;
                }

                mensagem.Codigo = ETipoCodigo.Errado;
                mensagem.Resposta = "Erro ao alterar Login";

                return mensagem;
            }
        }

        public MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Cadastrar(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            throw new NotImplementedException();
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                LoginModel Login;
                if (Objeto.GetType().Name.Contains("LoginModel"))
                {
                    Login = (LoginModel)Objeto;
                }
                else
                {
                    var Entidade = (Despachante)Objeto;
                    Login = (LoginModel)Entidade.Entidade;
                }


                var idCliente =
                    db.Login
                    .Where(x => x.Email == Login.Email && x.Senha == Login.Senha)
                    .Select(x => x.ClienteId).FirstOrDefault();
                if (idCliente == default)
                {
                    mensagem.Codigo = ETipoCodigo.Errado;
                    mensagem.Resposta = "Usuário nao encontrado";

                    return mensagem;
                }

                db.Cliente
                    .Include(x => x.Login)
                    .Where(x => x.StatusAtual == ETipoStatus.Ativo
                         && x.Login.Email == Login.Email && x.Login.Senha == Login.Senha).ToList()
                    .ForEach(x =>
                    {
                        x.Login.Cliente = null;
                        mensagem.Dados.Add(x);
                    });

                mensagem.Codigo = ETipoCodigo.Correto;
                mensagem.Resposta = "Usuário encontrado com sucesso";

                return mensagem;
            }
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

        public MensagemModel ConsultarPorId(Guid clienteId)
        {
            using (var db = new ToCBooksContext())
            {
                db.Cliente
                    .Include(x => x.Login)
                     .Where(x => x.StatusAtual == ETipoStatus.Ativo
                          && x.Login.ClienteId == clienteId).ToList()
                     .ForEach(x =>
                     {
                         x.Login.Cliente = null;
                         mensagem.Dados.Add(x);
                     });

                return mensagem;
            }
        }
    }
}
