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
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Creates new order.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="command"></param>
        /// <returns>A newly created order, and order lines.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Orders
        ///     {
        ///        "Country": "Country name" | null,
        ///        "City": "City name" | null,
        ///        "Address": "Address" | null,
        ///        "Phone": "Phone" | null,
        ///        "OrderLines": [
        ///              {
        ///                 "ProductId":2,
        ///                 "Quantity":1
        ///              }
        ///           ]
        ///         
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDTO data, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }

        
    }
}
