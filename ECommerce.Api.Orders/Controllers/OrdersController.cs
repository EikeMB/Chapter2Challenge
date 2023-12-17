using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	OrdersController.cs
* Description: 	Controller to have access to the orders  
  */
    [ApiController]
    [Route("api/orders")]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }


        /// <summary>
        /// Get orders specified by the customer Id.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the requested orders</response>
        /// <remarks>
        /// Sample request
        /// 
        /// <code>
        /// GET /orders/1
        /// [
        ///    {
        ///        "id": 1,
        ///        "customerId": 1,
        ///        "orderDate": "2023-12-16T19:08:06.3766461-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    },
        ///    {
        ///        "id": 2,
        ///        "customerId": 1,
        ///        "orderDate": "2023-12-16T19:08:06.4304803-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    }
        /// ]
        /// </code>
        /// </remarks>
        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);

            if(result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

        /// <summary>
        /// Get all Orders.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the all orders</response>
        /// <remarks>
        /// 
        /// Sample request
        /// <code>
        /// GET /orders
        /// [
        ///    {
        ///        "id": 1,
        ///        "customerId": 1,
        ///        "orderDate": "2023-12-16T19:08:06.3766461-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    },
        ///    {
        ///        "id": 2,
        ///        "customerId": 1,
        ///        "orderDate": "2023-12-16T19:08:06.4304803-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    },
        ///    {
        ///    "id": 3,
        ///        "customerId": 2,
        ///        "orderDate": "2023-12-16T19:08:06.4336822-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    },
        ///    {
        ///    "id": 4,
        ///        "customerId": 3,
        ///        "orderDate": "2023-12-16T19:08:06.4339164-05:00",
        ///        "total": 100,
        ///        "items": []
        ///    }
        ///]
        /// </code>
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await ordersProvider.GetOrdersAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

    }
}
