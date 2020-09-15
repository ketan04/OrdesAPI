using OrdersAPI.BuisnessServices;
using OrdersAPI.BusinessServices;
using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrdersAPI.Controllers
{
    public class OrderController : ApiController
    {
       [HttpGet]
       public IHttpActionResult GetOrders(int orderNumber)
        {
            
            OrderBusinessService orderBusinessService = new OrderBusinessService();

            List<OrderModel> orders = orderBusinessService.GetOrderByOrderNumber(orderNumber);

            if (orders != null && orders.Count > 0)
                return Ok(orders);
            else
                return NotFound();
        }
    }
}
