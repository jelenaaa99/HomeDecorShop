using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using HomeDecorShop.Application.UseCases.Queries;
using HomeDecorShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDecorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO data, [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }


        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
