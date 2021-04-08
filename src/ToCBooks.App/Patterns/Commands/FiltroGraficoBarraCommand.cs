using Microsoft.AspNetCore.Http;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Interfaces;
using ToCBooks.Data.Business.Patterns;


namespace ToCBooks.App.Patterns.Commands
{

    public class FiltroGraficoBarraCommand : ICommand
    {
        public MensagemModel Executar(EntidadeDominio Objeto, HttpContext SessionLink)
        {
            var Despachante = (Despachante)Objeto;
            return new Fachada().FiltroGraficoBarra((Periodo)Despachante.Entidade);
        }
    }
}
