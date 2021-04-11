using System.Collections.Generic;

namespace ToCBooks.Aplicacao.InputModels
{
    public class LivrosInputModel
    {

        public string Titulo { get; set; }
        public double Preco { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Paginas { get; set; }
        public List<CategoriaInputModel> Categorias { get; set; }
        public string Foto { get; set; }
    }
}
