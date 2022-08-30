using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using HomeDecorShop.Application.UseCases.Queries;
using HomeDecorShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {

        private readonly UseCaseHandler _handler;

        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<UsersController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterUserDTO data,[FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, data);

            return StatusCode(StatusCodes.Status201Created);
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
