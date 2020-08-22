using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Models
{
    public class LivrosModel : EntidadeDominio
    {
        public string Titulo { get; set; }
        public double Preco { get; set; }
        //public string Foto { get; set; }
        public string Descricao { get; set; }
    }
}
