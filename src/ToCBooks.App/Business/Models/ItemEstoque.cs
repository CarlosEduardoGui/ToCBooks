namespace ToCBooks.App.Business.Models
{
    public class ItemEstoque : EntidadeDominio
    {
        public LivrosModel Livro { get; set; }
        public int Qtde { get; set; }
    }
}
