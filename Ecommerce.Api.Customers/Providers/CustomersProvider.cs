﻿using AutoMapper;
using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Interfaces;
using Ecommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Providers
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	CustomersProvider.cs
* Description: 	Class that deals with the database and allows access to the data  
  */
    public class CustomersProvider : ICustomersProvider
    {

        private readonly CustomersDbContext dbContext;
        private readonly ILogger<CustomersProvider> logger;
        private readonly IMapper mapper;


        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Customers.Any())
            {
                dbContext.Customers.Add(new Db.Customer() { Id = 1, Name = "Eike", Address = "somewhere else ave" });
                dbContext.Customers.Add(new Db.Customer() { Id = 2, Name = "Aly", Address = "Boonies" });
                dbContext.Customers.Add(new Db.Customer() { Id = 3, Name = "Yensan", Address = "something ave"});
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool ISuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);

                if (customer != null)
                {
                    var result = mapper.Map<Db.Customer, Models.Customer>(customer);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception e)
            {

                logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }

        public async Task<(bool ISuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                var customers = await dbContext.Customers.ToListAsync();

                if (customers != null)
                {
                    var results = mapper.Map<IEnumerable<Db.Customer>, IEnumerable< Models.Customer >> (customers);
                    return (true, results, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception e)
            {

                logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
