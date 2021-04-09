namespace ToCBooks.Aplicacao.InputModels
{
    public class CategoriaInputModel
    {
        public CategoriaInputModel(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }

        public string NomeCategoria { get; private set; }
    }
}