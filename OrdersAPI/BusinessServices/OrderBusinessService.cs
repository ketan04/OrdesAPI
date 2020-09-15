using OrdersAPI.BusinessServices;
using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OrdersAPI.BuisnessServices
{
    public class OrderBusinessService
    {
        public List<OrderModel> GetOrderByOrderNumber(int orderNumber)
        {
            List<OrderModel> ordersList = new FileProcessBusinessService().GetOrdersFromXMLFile(Utils.Utils.xmlFilePath);
            return ordersList != null && ordersList.Count > 0 ? ordersList.Where(o => o.OrderNumber == orderNumber).ToList() : ordersList;
        }
    }
}