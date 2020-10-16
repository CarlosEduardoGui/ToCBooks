using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Commands;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;
using ToCBooks.App.Patterns.Commands;
using ToCBooks.App.Patterns.ViewHelpers;
using ToCBooks.App.ViewHelpers;

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
            mapCommand.Add("8", new AtualizarPrecoCommand());
            mapCommand.Add("9", new AdicionarItemCarrinhoCommand());
            mapCommand.Add("10", new ConsultarCarrinhoCommand());
            mapCommand.Add("11", new ExcluirItemCarrinho());
            mapCommand.Add("12", new AtualizarCarrinhoCommand());
            mapCommand.Add("13", new ConfirmarPedidoCommand());
            mapCommand.Add("14", new ProcessarPagamentosCommand());
            mapCommand.Add("15", new TrocaStatusAprovadoCommand());
            mapCommand.Add("16", new TrocaStatusEmTransitoCommand());
            mapCommand.Add("17", new TrocaStatusEntregueCommand());
            mapCommand.Add("18", new TrocaStatusEmTrocaCommand());


            mapVH.Add("PedidoModel", new PedidoVH());
            mapVH.Add("LivrosModel", new LivroVH());
            mapVH.Add("Parametro", new ParametroVH());
            mapVH.Add("ClienteModel", new ClienteVH());
            mapVH.Add("LoginModel", new LoginVH());
            mapVH.Add("CartaoCreditoModel", new CartaoCreditoVH());
            mapVH.Add("EnderecoEntregaModel", new EnderecoEntregaVH());
            mapVH.Add("EnderecoCobrancaModel", new EnderecoCobrancaVH());
            mapVH.Add("ItemEstoque", new ItemEstoqueVH());
            mapVH.Add("Carrinho", new CarrinhoVH());
            mapVH.Add("CupomModel", new CupomVH());
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
            var lVH = mapVH[HttpContext.Request.Form["mapKey"]];
            var lCommand = mapCommand[HttpContext.Request.Form["oper"]];

            Guid ClienteID = new Guid();
            if (HttpContext.Session.GetString("ClienteID") != null)
                ClienteID = Guid.Parse(HttpContext.Session.GetString("ClienteID"));

            var Despachante = new Despachante
            {
                Entidade = lVH.GetEntidade(HttpContext.Request.Form["JsonString"]),
                Login = new LoginModel
                {
                    ClienteId = ClienteID
                }
            };

            var lMensagem = lCommand.Executar(Despachante, HttpContext);
            return JsonConvert.SerializeObject(lMensagem, Formatting.Indented);
        }


        [HttpPost]
        [Route("Login")]
        public string Login()
        {
            var lVH = mapVH[HttpContext.Request.Form["mapKey"]];
            var lCommand = mapCommand[HttpContext.Request.Form["oper"]];
            var lMensagem = lCommand.Executar(lVH.GetEntidade(HttpContext.Request.Form["JsonString"]), HttpContext);
            if (lMensagem.Dados.Count() > 0)
                HttpContext.Session.SetString("ClienteID", lMensagem.Dados.Select(x => x.Id).FirstOrDefault().ToString());


            return JsonConvert.SerializeObject(lMensagem, Formatting.Indented);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
