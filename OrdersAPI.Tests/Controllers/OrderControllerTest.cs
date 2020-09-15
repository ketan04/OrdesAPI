using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OrdersAPI;
using OrdersAPI.Controllers;
using OrdersAPI.Models;

namespace OrdersAPI.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void GetOrdersForExistingOrderNumber()
        {
            // Arrange
            OrderController controller = new OrderController();
            // Act
            var result = controller.GetOrders(17890) as OkNegotiatedContentResult<List<OrderModel>>; 

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Count>0);
        }

        [TestMethod]
        public void GetOrdersForNonExistingOrderNumber()
        {
            // Arrange
            OrderController controller = new OrderController();
            List<OrderModel> ordrs = new List<OrderModel>();
            // Act
            IHttpActionResult result = controller.GetOrders(17891);



            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
