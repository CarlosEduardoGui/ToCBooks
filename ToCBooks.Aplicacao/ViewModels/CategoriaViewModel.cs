namespace ToCBooks.Aplicacao.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }
        public string NomeCategoria { get; private set; }

    }
}