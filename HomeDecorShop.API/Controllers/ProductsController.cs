using HomeDecorShop.API.Core.DTO;
using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using HomeDecorShop.Application.UseCases.Queries;
using HomeDecorShop.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDecorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly UseCaseHandler _handler;
        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IFindProductQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] ProductWithImgDTO data,[FromServices] ICreateProductCommand command)
        {
            if (data.Image != null)
            {
                var extensions = new List<string> { ".jpg", ".png", ".jpeg" };
                var guid = Guid.NewGuid().ToString();


                var extension = Path.GetExtension(data.Image.FileName);

                if (!extensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "img", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                data.Image.CopyTo(stream);

                data.Img = fileName;
            }

            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="204">Successfully deleted.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">User is not allowed to execute usecase.</response>
        /// <response code="404">Entity not found.</response>
        /// <response code="409">Can`t delete product because it is linked to another table.</response>
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            _handler.HandleCommand(command,id);
            return NoContent();
        }
    }
}
