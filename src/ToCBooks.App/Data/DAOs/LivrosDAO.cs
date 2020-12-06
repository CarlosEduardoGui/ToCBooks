using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Data.Context;
using ToCBooks.App.Data.Interfaces;
using System.Collections.Generic;

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
            MensagemModel Mensagem = new MensagemModel();

            using (var db = new ToCBooksContext())
            {
                var Livro = (LivrosModel)Objeto;
                LivrosModel LivroAtual = db.Livro
                    .Include(x => x.Precificacao)
                    .Where(x => x.Id == Objeto.Id).First();

                if (Livro.Preco > 0)
                    LivroAtual.Preco = Livro.Preco;

                if (Livro.Titulo != "" && Livro.Titulo != null)
                {
                    LivroAtual.Titulo = Livro.Titulo;
                    LivroAtual.Paginas = Livro.Paginas;
                    LivroAtual.Altura = Livro.Altura;
                    LivroAtual.Peso = Livro.Peso;
                    LivroAtual.Profundidade = Livro.Profundidade;
                    LivroAtual.Largura = Livro.Largura;
                    LivroAtual.ISBN = Livro.ISBN;
                    LivroAtual.Foto = Livro.Foto;
                    LivroAtual.Descricao = Livro.Descricao;
                    LivroAtual.Ano = Livro.Ano;
                    LivroAtual.Edicao = Livro.Edicao;
                    LivroAtual.Editora = Livro.Editora;
                    LivroAtual.CodigoDeBarras = Livro.CodigoDeBarras;
                    LivroAtual.Autor = Livro.Autor;
                    LivroAtual.Categorias = Livro.Categorias;
                }
                db.Livro.Update(LivroAtual);
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
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

        public MensagemModel ConsultaCustomizada(EntidadeDominio Objeto)
        {
            var Livro = (LivrosModel)Objeto;
            Expression<Func<LivrosModel, bool>> Busca = x => x.Titulo.Contains(Livro.Titulo)
            && x.StatusAtual == Livro.StatusAtual && x.Autor.Contains(Livro.Autor) && x.Editora.Contains(Livro.Editora);
            //&& x.CodigoDeBarras.Contains(Livro.CodigoDeBarras) && x.Ano == Livro.Ano && x.Edicao <= Livro.Edicao
            //&& x.Paginas <= Livro.Paginas && x.Altura <= Livro.Altura && x.Largura <= Livro.Largura && x.Peso <=Livro.Peso
            //&& x.Profundidade <= Livro.Profundidade && x.ISBN.Contains(Livro.ISBN);

            return Buscar(Busca);
        }

        public MensagemModel OrdenarPreco()
        {
            var Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                db.Livro.OrderByDescending(x => x.Preco)
                    .ToList()
                    .ForEach(x => { Mensagem.Dados.Add(x); });
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Dados encontrados";

            return Mensagem;
        }


        public MensagemModel OrdenarNome()
        {
            var Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                db.Livro.OrderBy(x => x.Titulo)
                    .Where(x => x.StatusAtual == ETipoStatus.Ativo)
                    .ToList()
                    .ForEach(x => { Mensagem.Dados.Add(x); });
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Dados encontrados";

            return Mensagem;
        }

        public MensagemModel Buscar(Expression<Func<LivrosModel, bool>> predicate)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {

                db.Livro
                    .Include(x => x.Precificacao)
                    .Include(x => x.Categorias)
                    .Where(predicate.Compile()).ToList().ForEach(x =>
                    {
                        Mensagem.Dados.Add(x);
                    });

            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
        }

        public MensagemModel Consultar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                LivrosModel Livro;
                if (Objeto.GetType().Name == "Despachante")
                {
                    var Despachante = (Despachante)Objeto;
                    Livro = (LivrosModel)Despachante.Entidade;
                }
                else
                    Livro = (LivrosModel)Objeto;


                var ObjetoPersistido = db.Livro.Find(Livro.Id);
                if (ObjetoPersistido != null)
                {
                    db.Livro.Include(x => x.Precificacao)
                        .Include(x => x.Categorias)
                        .Where(x => x.Id == Livro.Id)
                        .OrderByDescending(x => x.DataCadastro).ToList()
                        .ForEach(x => Mensagem.Dados.Add(x));

                }
                else
                {
                    db.Livro
                        .Include(x => x.Precificacao)
                        .Include(x => x.Categorias)
                        .Where(x => x.StatusAtual == ETipoStatus.Ativo)
                        .OrderByDescending(x => x.DataCadastro).ToList()
                        .ForEach(x => Mensagem.Dados.Add(x));
                }
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso ...";

            return Mensagem;
        }

        public MensagemModel Desativar(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                LivrosModel Livro = db.Livro.Find(Objeto.Id);
                Livro.StatusAtual = ETipoStatus.Inativo;
                Livro.Justificativa = Objeto.Justificativa;
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Livro Desativado...";

            return Mensagem;
        }

        public MensagemModel AtualizarPreco(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                var Livro = (LivrosModel)Objeto;
                var LivroAtual = db.Livro
                    .Include(x => x.Precificacao)
                    .Include(x => x.Categorias)
                    .Where(x => x.Id == Objeto.Id).First();

                LivroAtual.Preco = Livro.Preco;
                db.Livro.Update(LivroAtual);
                db.SaveChanges();
            }

            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Preço Atualizado Com Sucesso ...";

            return Mensagem;
        }


        public MensagemModel ConsultarPorAutor(EntidadeDominio Objeto)
        {
            MensagemModel Mensagem = new MensagemModel();
            using (var db = new ToCBooksContext())
            {
                LivrosModel Livro;
                if (Objeto.GetType().Name == "Despachante")
                {
                    var Despachante = (Despachante)Objeto;
                    Livro = (LivrosModel)Despachante.Entidade;
                }
                else
                    Livro = (LivrosModel)Objeto;

                db.Livro
                        .Include(x => x.Precificacao)
                        .Include(x => x.Categorias)
                        .Where(x => x.StatusAtual == ETipoStatus.Ativo && x.Autor == Livro.Autor)
                        .OrderByDescending(x => x.Autor).ToList()
                        .ForEach(x => Mensagem.Dados.Add(x));
            }

            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Livro consultado com sucesso";

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

        public MensagemModel ConsultarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
