using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	IOrdersProvider.cs
* Description: 	Interface for the order provider class 
  */
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);

        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync();


    }
}
