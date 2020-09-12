using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class LoginModel : EntidadeDominio
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }
    }
}
