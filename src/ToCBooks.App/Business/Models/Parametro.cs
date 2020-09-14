namespace ToCBooks.App.Business.Models
{
    public class Parametro : EntidadeDominio
    {
        public enum TipoParametro
        {
            GrupoPrecificacao = 0,
            ValorInativacao = 1
        }

        public string Nome { get; set; }
        public double Valor { get; set; }
        public TipoParametro Tipo { get; set; }

    }
}
