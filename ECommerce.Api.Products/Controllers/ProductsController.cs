using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	ProductsController.cs
* Description: 	Controller to have access to the products  
  */
    [ApiController]
    [Route("api/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the all products</response>
        /// <remarks>
        /// Sample request
        /// <code>
        /// GET /prodcuts
        /// [
        ///    {
        ///        "id": 1,
        ///        "name": "Keyboard",
        ///        "price": 20,
        ///        "inventory": 100
        ///    },
        ///    {
        ///        "id": 2,
        ///        "name": "Mouse",
        ///        "price": 5,
        ///        "inventory": 200
        ///    },
        ///    {
        ///    "id": 3,
        ///        "name": "Monitor",
        ///        "price": 150,
        ///        "inventory": 100
        ///    },
        ///    {
        ///      "id": 4,
        ///      "name": "CPU",
        ///      "price": 200,
        ///      "inventory": 2000
        ///    }
        /// ]
        /// </code>
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }


        /// <summary>
        /// Get product by the provided Id.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested product</response>
        /// <remarks>
        /// Sample request
        /// <code>
        /// GET /products/1
        /// {
        ///    "id": 1,
        ///    "name": "Keyboard",
        ///    "price": 20,
        ///    "inventory": 100
        /// }
        /// </code>
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
