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
        public IActionResult Post()
        {
            return Ok("");
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
