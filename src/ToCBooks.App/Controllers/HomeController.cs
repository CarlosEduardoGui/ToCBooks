﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;
using ToCBooks.App.Commands;
using ToCBooks.App.ViewHelpers;

namespace ToCBooks.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            mapCommand.Add("1", new ConsultarLivrosCommand());
            mapCommand.Add("2", new CadastrarLivroCommand());

            mapVH.Add("Livro", new LivroVH());
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
        [IgnoreAntiforgeryToken]
        public string Operations()
        {
            var lVH = mapVH[HttpContext.Request.Form["mapKey"]];
            var lCommand = mapCommand[HttpContext.Request.Form["oper"]];
            var lMensagem = lCommand.Executar(lVH.GetEntidade(HttpContext.Request.Form["JsonString"]));

            return lMensagem.Resposta;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
