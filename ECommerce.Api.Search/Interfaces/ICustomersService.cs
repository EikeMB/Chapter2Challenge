using ECommerce.Api.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    public interface ICustomersService
    {
        Task<(bool IsSuccess, dynamic Customers, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
