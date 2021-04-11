using System.Collections.Generic;

namespace ToCBooks.Aplicacao.ViewModels
{
    public class LivrosViewModel
    {
        public LivrosViewModel(string titulo, double preco, string autor, string editora, int paginas, string foto)
        {
            Titulo = titulo;
            Preco = preco;
            Autor = autor;
            Editora = editora;
            Paginas = paginas;
            Foto = foto;

            Categorias = new List<CategoriaViewModel>();
        }

        public string Titulo { get; private set; }
        public double Preco { get; private set; }
        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public int Paginas { get; private set; }
        public List<CategoriaViewModel> Categorias { get; private set; }
        public string Foto { get; private set; }
    }
}
