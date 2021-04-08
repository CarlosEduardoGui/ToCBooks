namespace ToCBooks.Domain.Entidades
{
    public class Categoria : EntidadeDominio
    {
        public Categoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }

        public string NomeCategoria { get; private set; }
    }
}
