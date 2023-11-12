using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Customers.Db
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	CustomersDbContext.cs
* Description: 	Class that creates the database context for the customer class  
  */
    public class CustomersDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set;}

        public CustomersDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
