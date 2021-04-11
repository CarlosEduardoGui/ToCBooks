using System;
using System.Collections.Generic;
using System.Linq;
using ToCBooks.Aplicacao.InputModels;
using ToCBooks.Aplicacao.Servicos.Interfaces;
using ToCBooks.Aplicacao.ViewModels;
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
            var a = _dbContext.Livros;
            var ListLivros = new List<LivrosViewModel>();
            var ListCategoriaMoq = new List<CategoriaViewModel>();

            var CategoriaMoq = new CategoriaViewModel("ficção");
            var CategoriaMoq2 = new CategoriaViewModel("aventura");

            ListCategoriaMoq.Add(CategoriaMoq);
            ListCategoriaMoq.Add(CategoriaMoq2);

            var LivroMoq = new LivrosViewModel("teste", 0.00, "carlos", "editora", 10, ListCategoriaMoq, "...");
            var LivroMoq2 = new LivrosViewModel("teste", 0.00, "carlos", "editora", 10, ListCategoriaMoq, "...");

            ListLivros.Add(LivroMoq);
            ListLivros.Add(LivroMoq2);

            return ListLivros;
            //var livroResultado = _dbContext.Livros;

            //var categorias = new List<CategoriaViewModel>();
            //foreach (var item in livroResultado.Select(x => x.Categorias).ToList())
            //{
            //    foreach (var i in item)
            //    {
            //        var categoria = new CategoriaViewModel(i.NomeCategoria);
            //        categorias.Add(categoria);
            //    }
            //}

            //var livroViewModel = livroResultado.Select(l => new LivrosViewModel(l.Titulo, l.Preco, l.Autor, l.Editora, l.Paginas, categorias, l.Foto)).ToList();

            //return livroViewModel;
        }

        public LivrosViewModel GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public LivrosInputModel Update(LivrosInputModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
