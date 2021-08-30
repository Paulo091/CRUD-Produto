using CRUD.Produtos.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var produto = _repository.SelecionarPorId(id);

                if (produto.ProdutoId == 0)
                    return NotFound("Produto não encontrado");

                return Ok(produto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.ListarTodos());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
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
        public IActionResult Put(Models.Produtos produtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                return Ok(_repository.Atualizar(produtos));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Deletar(id);
            return NoContent();
        }
    }
}
