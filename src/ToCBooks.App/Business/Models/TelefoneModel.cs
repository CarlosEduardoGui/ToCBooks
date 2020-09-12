using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class TelefoneModel : EntidadeDominio
    {
        public int DDD { get; set; }

        public int Numero { get; set; }

        public ETipoTelefone Tipo { get; set; }
    }
}
