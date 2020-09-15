using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OrdersAPI.BusinessServices
{
    public class FileProcessBusinessService
    {

        public void ProcessDirectoryForXMLCreation(string targetDirectory, string xmlFilePath)
        {
            try
            {
                // Process the list of files found in the directory.
                List<OrderModel> ordersList = new List<OrderModel>();
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                List<OrderModel> orders = new List<OrderModel>();
                foreach (string fileName in fileEntries)
                    orders.AddRange(AddOrderInXMLFile(fileName, xmlFilePath));

                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Append))
                {
                    new XmlSerializer(typeof(List<OrderModel>)).Serialize(fs, orders);
                }
            }
            catch(Exception e)
            {
                //If time permits create a logger file and log it in the log file
                Console.WriteLine(e.Message);
            }
        }

        private List<OrderModel> AddOrderInXMLFile(string fileName, string xmlFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                List<OrderModel> orderslist = new List<OrderModel>();

                //this loop is designed to start at index 1 to ignore headers in text files.
                for(int i=1; i<lines.Length; i++)
                {
                    string line = lines[i];
                    string[] contents = line.Split(new char[] { '|' });
                    OrderModel orders = new OrderModel {
                        OrderNumber = int.Parse(contents[1]),
                        OrderLineNumber = int.Parse(contents[2]),
                        ProductNumber = contents[3],
                        Quantity = int.Parse(contents[4]),
                        Name = contents[5],
                        Description = contents[6],
                        Price = float.Parse(contents[7]),
                        ProductGroup = contents[8],
                        OrderDate = DateTime.Parse(contents[9]).Date,
                        CustomerName = contents[10],
                        CustomerNumber = int.Parse(contents[11])
                    };
                    orderslist.Add(orders);
                }
                return orderslist;
            }catch(Exception e)
            {
                //If time permits create a logger file and log it in the log file
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<OrderModel> GetOrdersFromXMLFile(string fileName)
        {
            try
            {
                List<OrderModel> ordersList = new List<OrderModel>();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderModel>));
                using (Stream reader = new FileStream(fileName, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    ordersList =(List<OrderModel>)xmlSerializer.Deserialize(reader);
                }

                return ordersList;
            }catch(Exception e)
            {
                //If time permits create a logger file and log it in the log file
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}