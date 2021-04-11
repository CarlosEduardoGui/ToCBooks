namespace ToCBooks.Domain.Entidades
{
    public class LivrosCategorias : EntidadeDominio
    {
        public LivrosCategorias(long idCategoria, long idLivro)
        {
            IdCategoria = idCategoria;
            IdLivro = idLivro;
        }


        public Livros Livro { get; private set; }
        public long IdLivro { get; private set; }

        public Categoria Categoria { get; private set; }
        public long IdCategoria { get; private set; }

    }
}
