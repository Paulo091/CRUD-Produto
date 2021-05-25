using CRUD.Produtos.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Produtos.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProdutoController : ControllerBase
    {
        
        private readonly IDefaultRepository<Models.Produtos> _repository;
        public ProdutoController(IDefaultRepository<Models.Produtos> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(Models.Produtos produto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                return Ok(_repository.Inserir(produto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
