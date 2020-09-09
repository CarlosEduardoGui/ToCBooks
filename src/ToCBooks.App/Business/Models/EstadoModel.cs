namespace ToCBooks.App.Business.Models
{
    public class EstadoModel : EntidadeDominio
    {
        public string Nome { get; set; }
        public PaisModel Pais { get; set; }
    }
}
