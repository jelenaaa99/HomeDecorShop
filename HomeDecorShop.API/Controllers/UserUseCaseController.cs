using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDecorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserUseCaseController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public UserUseCaseController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPut]
        public IActionResult Put(
            [FromBody] UpdateUserUseCaseDTO request,
            [FromServices] IUpdateUserUseCaseCommand command)
        {
            _handler.HandleCommand(command, request);
            return NoContent();
        }
    }
}
