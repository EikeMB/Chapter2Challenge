using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }


        /// <summary>
        /// Get all Customer info and all orders by the customer Id.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the requested customer info and orders</response>
        /// <remarks>
        /// Sample request
        /// 
        /// <code>
        /// POST /search
        /// 
        /// Body: {
        ///         CustomerId: 1
        ///       }
        ///       
        /// 
        /// {
        ///    "customer": {
        ///        "id": 1,
        ///        "name": "Eike",
        ///       "address": "somewhere else ave"
        ///    },
        ///    "orders": [
        ///        {
        ///            "id": 1,
        ///            "orderDate": "2023-12-16T19:08:06.3766461-05:00",
        ///            "total": 100,
        ///            "items": [
        ///                {
        ///                    "id": 1,
        ///                    "productId": 1,
        ///                    "productName": "Keyboard",
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///               },
        ///                {
        ///                    "id": 2,
        ///                    "productId": 2,
        ///                    "productName": "Mouse",
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///    "id": 3,
        ///                    "productId": 3,
        ///                    "productName": "Monitor",
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///    "id": 4,
        ///                    "productId": 2,
        ///                    "productName": "CPU",
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///    "id": 5,
        ///                    "productId": 3,
        ///                    "productName": null,
        ///                    "quantity": 1,
        ///                    "unitPrice": 100
        ///                }
        ///            ]
        ///        },
        ///        {
        ///    "id": 2,
        ///           "orderDate": "2023-12-16T19:08:06.4304803-05:00",
        ///            "total": 100,
        ///            "items": [
        ///                {
        ///        "id": 6,
        ///                    "productId": 1,
        ///                    "productName": null,
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///        "id": 7,
        ///                    "productId": 2,
        ///                    "productName": null,
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///        "id": 8,
        ///                    "productId": 3,
        ///                    "productName": null,
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///        "id": 9,
        ///                    "productId": 2,
        ///                    "productName": null,
        ///                    "quantity": 10,
        ///                    "unitPrice": 10
        ///                },
        ///                {
        ///        "id": 10,
        ///                    "productId": 3,
        ///                    "productName": null,
        ///                    "quantity": 1,
        ///                    "unitPrice": 100
        ///                }
        ///            ]
        ///       }
        ///    ]
        ///}
        ///</code>
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);

            if(result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }
    }
}
