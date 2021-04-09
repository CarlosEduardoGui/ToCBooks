using System.Collections.Generic;

namespace ToCBooks.Aplicacao.InputModels
{
    public class LivrosInputModel
    {
        public LivrosInputModel(string titulo, double preco, string autor, string editora, int paginas, List<CategoriaInputModel> categorias, string foto)
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
        public List<CategoriaInputModel> Categorias { get; private set; }
        public string Foto { get; private set; }
    }
}
