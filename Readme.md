# OrdersAPI
>Orders API is a solution developed to enable integration of orders data with multiple applications. At present it's public API has only one endpoint which returns orders based on the ordernumbers. This solution uses a console application to generate XML orders files from multiple text files consisting orders information.

# Design Elaboration
  * Console Application
        Console Application is created to read text files located in a directory and then creates an XML file in the directory. 
        Notes:-
        For console application to run successflly please keep the all text order files in one repository and define the file name and path for output xml file.
        1. The path of text files directory is configurable in Util class
        2. The path and name of XML file is configurable in Util class
        
  * Web API Endpoint
        http://localhost:60798/api/Order/GetOrders?orderNumber= 
        This endpoint will return all the orders against the order number provided.
  * Unit tesing: 
        Unit test project has two basic test cases for valid and invalid order number.





