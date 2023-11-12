using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Db
{ /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	ProductsDbContext.cs
* Description: 	Class that creates the database context for the product class  
  */
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}

        public ProductsDbContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}
