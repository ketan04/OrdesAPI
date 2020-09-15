using OrdersAPI.BusinessServices;
using OrdersAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProcessBusinessService fileProcessBusinessService = new FileProcessBusinessService();
            Console.WriteLine("Starting files reading and xml file creation process");
            fileProcessBusinessService.ProcessDirectoryForXMLCreation(Utils.textFileDirectory, Utils.xmlFilePath);
            Console.WriteLine("XML File Created");

        }
    }
}
