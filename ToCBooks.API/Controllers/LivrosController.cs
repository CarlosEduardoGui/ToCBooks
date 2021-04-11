using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.Aplicacao.InputModels;
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


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_livroServico.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var livro = _livroServico.GetByID(id);

            return livro == null ? NotFound(id) : Ok(livro);
        }


        [HttpPost]
        public IActionResult PostLivro([FromBody] LivrosInputModel model)
        {
            return ModelState.IsValid
                ? CreatedAtAction(nameof(GetById), new { id = _livroServico.Create(model) }, model)
                : BadRequest("Modelo inválida");
        }
    }
}
