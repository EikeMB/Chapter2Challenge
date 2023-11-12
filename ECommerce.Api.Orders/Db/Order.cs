using System;
using System.Collections.Generic;

namespace ECommerce.Api.Orders.Db
{
    /*
* Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Eike Morgado Bodecker - 2137571
* Date: 		<12> <November> 2023
* Class Name: 	Order.cs
* Description: 	Order class that has an Id a CustomerId OrderDate a total cost and a list of order items 
 */
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
