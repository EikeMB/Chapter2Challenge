using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Db
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	OrdersDbContext.cs
* Description: 	Class that creates the database context for the order and orderItem class  
  */
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrdersDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
