using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Interfaces
{
    public interface ICustomersProvider
    {

        Task<(bool ISuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync();

        Task<(bool ISuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
