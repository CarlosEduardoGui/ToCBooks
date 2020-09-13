namespace ToCBooks.App.Business.Models
{
    public class Despachante : EntidadeDominio
    {
        public EntidadeDominio Entidade { get; set; }
        public LoginModel Login { get; set; }
    }
}