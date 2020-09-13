using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToCBooks.App.Models;
using ToCBooks.App.Commands;
using ToCBooks.App.ViewHelpers;
using ToCBooks.App.Patterns.Commands;
using ToCBooks.App.Interfaces;
using Newtonsoft.Json;
using ToCBooks.App.Patterns.ViewHelpers;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ToCBooks.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            mapCommand.Add("1", new ConsultarCommand());
            mapCommand.Add("2", new CadastrarCommand());
            mapCommand.Add("3", new DesativarCommand());
            mapCommand.Add("4", new ExcluirCommand());
            mapCommand.Add("5", new BuscarCommand());
            mapCommand.Add("6", new AtivarCommand());
            mapCommand.Add("7", new LoginCommand());

            mapVH.Add("LivrosModel", new LivroVH());
            mapVH.Add("Parametro", new ParametroVH());
            mapVH.Add("ClienteModel", new ClienteVH());
            mapVH.Add("LoginModel", new LoginVH());
            mapVH.Add("CartaoCreditoModel", new CartaoCreditoVH());
        }

        private Dictionary<string, IViewHelper> mapVH = new Dictionary<string, IViewHelper>();
        private Dictionary<string, ICommand> mapCommand = new Dictionary<string, ICommand>();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Teste")]
        public ViewResult Teste()
        {
            return View("testes_les");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [Route("Operations")]
        public string Operations()
        {
            var sessao = HttpContext.Session.GetString("ClienteID");

            var lVH = mapVH[HttpContext.Request.Form["mapKey"]];
            var lCommand = mapCommand[HttpContext.Request.Form["oper"]];
            var lMensagem = lCommand.Executar(lVH.GetEntidade(HttpContext.Request.Form["JsonString"]));

            return JsonConvert.SerializeObject(lMensagem, Formatting.Indented);
        }
        

        [HttpPost]
        [Route("Login")]
        public string Login() 
        {
            var lVH = mapVH[HttpContext.Request.Form["mapKey"]];
            var lCommand = mapCommand[HttpContext.Request.Form["oper"]];
            var lMensagem = lCommand.Executar(lVH.GetEntidade(HttpContext.Request.Form["JsonString"]));

            HttpContext.Session.SetString("ClienteID", lMensagem.Dados.Select(x => x.Id).FirstOrDefault().ToString());

            return JsonConvert.SerializeObject("Login efetuado com sucesso!", Formatting.Indented);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
