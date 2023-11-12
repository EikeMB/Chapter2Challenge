using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Interfaces
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	ICustomersProvider.cs
* Description: 	Interface for the customer provider class 
  */
    public interface ICustomersProvider
    {

        Task<(bool ISuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync();

        Task<(bool ISuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
