using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.Aplicacao.Servicos.Interfaces;

namespace ToCBooks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivrosServico _livroServico;

        public LivrosController(ILivrosServico livroServico)
        {
            _livroServico = livroServico;
        }


        /// <summary>
        /// Captura todos os Livros já cadastrados no sistema
        /// </summary>
        /// <returns>Retorna todos os Livros cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_livroServico.GetAll());

        }
    }
}
