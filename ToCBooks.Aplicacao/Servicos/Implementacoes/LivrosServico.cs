using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.Aplicacao.InputModels;
using ToCBooks.Aplicacao.Servicos.Interfaces;
using ToCBooks.Aplicacao.ViewModels;
using ToCBooks.Domain.Entidades;
using ToCBooks.Infraestrutura.Context;

namespace ToCBooks.Aplicacao.Servicos.Implementacoes
{
    public class LivrosServico : ILivrosServico
    {
        private readonly ToCBooksDbContext _dbContext;

        public LivrosServico(ToCBooksDbContext context)
        {
            _dbContext = context;
        }


        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IList<LivrosViewModel> GetAll()
        {
            //var a = _dbContext.Livros;
            //var ListLivros = new List<LivrosViewModel>();
            //var ListCategoriaMoq = new List<CategoriaViewModel>();

            //var CategoriaMoq = new CategoriaViewModel("ficção");
            //var CategoriaMoq2 = new CategoriaViewModel("aventura");

            //ListCategoriaMoq.Add(CategoriaMoq);
            //ListCategoriaMoq.Add(CategoriaMoq2);

            //var LivroMoq = new LivrosViewModel("teste", 0.00, "carlos", "editora", 10, ListCategoriaMoq, "...");
            //var LivroMoq2 = new LivrosViewModel("teste", 0.00, "carlos", "editora", 10, ListCategoriaMoq, "...");

            //ListLivros.Add(LivroMoq);
            //ListLivros.Add(LivroMoq2);

            //return ListLivros;
            var livroResultado = _dbContext.Livros;

            var livroViewModel = livroResultado.Select(l => new LivrosViewModel(l.Titulo, l.Preco, l.Autor, l.Editora, l.Paginas ,l.Foto)).ToList();

            return livroViewModel;
        }

        public LivrosViewModel GetByID(object id)
        {
            var livro = _dbContext.Livros
                .Include(x => x.Categorias)
                .SingleOrDefault(x => x.Id == (long)id);

            return new LivrosViewModel(livro.Titulo, livro.Preco, livro.Autor, livro.Editora, livro.Paginas, livro.Foto);
        }

        public long Create(LivrosInputModel model)
        {
            var livrosCategorias = new List<Categoria>();
            foreach (var item in model.Categorias)
            {
                livrosCategorias.Add(new Categoria(item.NomeCategoria));
            }

            var livro = new Livros(model.Titulo, model.Preco, model.Autor, model.Editora, model.Paginas, model.Foto);

            _dbContext.Livros.Add(livro);

            _dbContext.SaveChanges();

            return livro.Id;
        }

        public LivrosInputModel Update(LivrosInputModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
