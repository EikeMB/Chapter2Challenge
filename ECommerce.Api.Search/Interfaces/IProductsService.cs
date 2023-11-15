﻿using ECommerce.Api.Search.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    public interface IProductsService
    {
        Task<(bool ISuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();
    }
}
