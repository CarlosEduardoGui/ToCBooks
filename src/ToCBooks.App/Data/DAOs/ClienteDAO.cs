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
                    mensagem.Codigo = ETipoCodigo.Correto;
                    mensagem.Resposta = "Cliente atualizado!";

                    return mensagem;
                }

                mensagem.Codigo = ETipoCodigo.Errado;
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

                if (result == 12)
                {
                    mensagem.Codigo = ETipoCodigo.Correto;
                    mensagem.Resposta = "Cliente foi cadastrado com sucesso";

                    return mensagem;
                }

                mensagem.Codigo = ETipoCodigo.Errado;
                mensagem.Resposta = "Erro ao cadastrar Cliente";

                return mensagem;
            }
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                var Despachante = (Despachante)Objeto;
                var Cliente = (ClienteModel)Despachante.Entidade;

                var ObjetoPersistido = db.Cliente
                        .Include(x => x.Login)
                        .Include(x => x.EnderecoCobranca)
                        .Include(x => x.EnderecoEntrega)
                        .Include(x => x.CartaoCredito)
                        .Include(x => x.Telefone)
                        .Where(x => x.Id == Despachante.Login.ClienteId).ToList().FirstOrDefault();

                if (ObjetoPersistido != null)
                {
                    ObjetoPersistido.Login.Cliente = null;
                    ObjetoPersistido.EnderecoCobranca.ForEach(x => x.Cliente = null);
                    ObjetoPersistido.EnderecoEntrega.ForEach(x => x.Cliente = null);
                    ObjetoPersistido.CartaoCredito.ForEach(x => x.Cliente = null);

                    mensagem.Dados.Add(ObjetoPersistido);
                }

                else
                    db.Cliente
                        .Include(x => x.Login)
                        .Include(x => x.EnderecoCobranca)
                        .Include(x => x.EnderecoEntrega)
                        .Include(x => x.CartaoCredito)
                        .Include(x => x.Telefone)
                        .Where(x => x.StatusAtual == ETipoStatus.Ativo).ToList().ForEach(x =>
                        {
                            x.Login.Cliente = null;
                            x.EnderecoCobranca.ForEach(y =>
                            {
                                y.Cliente = null;
                                y = db.EnderecoCobranca
                                .Include(z => z.Cidade)
                                .Include(z => z.Cidade.Estado)
                                .Include(z => z.Cidade.Estado.Pais)
                                .Where(z => z.Id == y.Id).First();
                            });
                            x.EnderecoEntrega.ForEach(y =>
                            {
                                y.Cliente = null;
                                y = db.EnderecoEntrega
                                .Include(z => z.Cidade)
                                .Include(z => z.Cidade.Estado)
                                .Include(z => z.Cidade.Estado.Pais)
                                .Where(z => z.Id == y.Id).First();
                            });
                            x.CartaoCredito.ForEach(y => y.Cliente = null);

                            mensagem.Dados.Add(x);
                        });

                mensagem.Codigo = ETipoCodigo.Correto;
                mensagem.Resposta = "Cliente consultado com sucesso";

                return mensagem;
            }
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            using (var db = new ToCBooksContext())
            {
                ClienteModel Cliente = db.Find<ClienteModel>(Objeto.Id);
                Cliente.StatusAtual = ETipoStatus.Inativo;
                Cliente.Justificativa = Objeto.Justificativa;
                db.SaveChanges();
            }

            mensagem.Codigo = ETipoCodigo.Correto;
            mensagem.Resposta = "Cliente Desativado...";

            return mensagem;
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

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            var Cliente = (ClienteModel)Objeto;
            Expression<Func<ClienteModel, bool>> Busca = x => x.Nome == Cliente.Nome
            && x.CPF == Cliente.CPF && x.Telefone.Numero == Cliente.Telefone.Numero
            && x.Login.Email == Cliente.Login.Email;

            return Buscar(Busca);
        }

        public MensagemModel Buscar(Expression<Func<ClienteModel, bool>> predicate)
        {
            using (var db = new ToCBooksContext())
            {
                db.Cliente
                    .Include(x => x.Telefone)
                    .Include(x => x.Login)
                    .Where(predicate.Compile()).ToList().ForEach(x =>
                    {
                        x.Login.Cliente = null;
                        mensagem.Dados.Add(x);
                    });

            }

            mensagem.Codigo = ETipoCodigo.Correto;
            mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return mensagem;
        }

        public bool ClienteExiste(ClienteModel model)
        {
            using (var db = new ToCBooksContext())
            {
                var resultado = db.Cliente
                    .Include(x => x.Login)
                    .Where(x => x.Login.Email == model.Login.Email).Any();

                return resultado;
            }
        }
    }
}
