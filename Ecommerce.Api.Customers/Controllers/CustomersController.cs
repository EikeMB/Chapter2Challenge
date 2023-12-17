using Ecommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Controllers
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	CustomersController.cs
* Description: 	Controller to have access to the customers  
   */

    [ApiController]
    [Route("api/customers")]
    [Produces("application/json")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }


        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the all customers</response>
        /// <remarks>
        /// Sample request
        /// <code>
        /// 
        /// GET /customers/1
        /// [
        ///    {
        ///        "id": 1,
        ///        "name": "Eike",
        ///        "address": "somewhere else ave"
        ///    },
        ///    {
        ///        "id": 2,
        ///        "name": "Aly",
        ///        "address": "Boonies"
        ///    },
        ///    {
        ///        "id": 3,
        ///        "name": "Yensan",
        ///        "address": "something ave"
        ///    }
        /// ]
        /// </code>
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();

            if (result.ISuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }


        /// <summary>
        /// Get customer by the provided Id.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the requested customer</response>
        /// <remarks>
        /// Sample request:
        /// <code>
        /// GET /customers
        ///     {
        ///         "id": 1,
        ///         "name": "Eike",
        ///         "address": "somewhere else ave"
        ///     } 
        /// </code>
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);

            if (result.ISuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
