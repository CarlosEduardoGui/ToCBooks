using System.Collections.Generic;

namespace ToCBooks.Domain.Entidades
{
    public class Livros : EntidadeDominio
    {
        public Livros(string titulo, double preco, string autor, string editora, int paginas, List<Categoria> categorias, string foto)
        {
            Titulo = titulo;
            Preco = preco;
            Autor = autor;
            Editora = editora;
            Paginas = paginas;
            Categorias = categorias;
            Foto = foto;
        }

        public string Titulo { get; private set; }
        public double Preco { get; private set; }
        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public int Paginas { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public string Foto { get; private set; }

    }
}
