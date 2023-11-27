using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	OrdersProvider.cs
* Description: 	Class that deals with the database and allows access to the data  
  */
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<IOrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.Add(new Db.Order() { Id = 1, CustomerId = 1, OrderDate = DateTime.Now, orderItems = new List<Db.OrderItem>() { new Db.OrderItem() }, Total = 50 });
                dbContext.Orders.Add(new Db.Order() { Id = 2, CustomerId = 1, OrderDate = DateTime.Now, orderItems = new List<Db.OrderItem>() { new Db.OrderItem() }, Total = 50 });
                dbContext.Orders.Add(new Db.Order() { Id = 3, CustomerId = 2, OrderDate = DateTime.Now, orderItems = new List<Db.OrderItem>() { new Db.OrderItem() }, Total = 50 });
                dbContext.Orders.Add(new Db.Order() { Id = 4, CustomerId = 3, OrderDate = DateTime.Now, orderItems = new List<Db.OrderItem>() { new Db.OrderItem() }, Total = 50 });
                dbContext.SaveChanges();
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await dbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();

                if(orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>> (orders);

                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return(false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync()
        {
            try
            {
                var orders = await dbContext.Orders.ToListAsync();

                if (orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);

                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
