using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class TelefoneModel
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }


    public enum TipoTelefone
    {
        Fixo,
        Celular
    }
}
