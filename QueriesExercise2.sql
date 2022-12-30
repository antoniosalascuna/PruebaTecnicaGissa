/****** Script for SelectTopNRows command from SSMS  ******/
  SELECT 
	     SI.CustomerID,			
		 SC.CustomerName, 
         SI.InvoiceDate,
		 AD.DeliveryMethodName,
         SI.InvoiceID,
		 PE.FullName
  FROM WWIDB.Sales.Invoices  SI
  JOIN WWIDB.Sales.Customers SC ON SI.CustomerID = SC.CustomerID
  JOIN WWIDB.Application.DeliveryMethods AD ON SI.DeliveryMethodID = AD.DeliveryMethodID
  JOIN WWIDB.Application.People PE ON SI.SalespersonPersonID = PE.PersonID
  WHERE SI.InvoiceDate BETWEEN  '2013-01-01' AND '2015-12-31'


  SELECT 
		 SC.CustomerID,
		 SC.CustomerName,
		 COUNT (SI.InvoiceID) AS TotalInvoice,
		 COUNT (SI.InvoiceID) + 1 'Consecutivo'
  FROM WWIDB.Sales.Invoices SI 
  JOIN WWIDB.Sales.Customers SC ON SI.CustomerID = SC.CustomerID
  GROUP BY SC.CustomerName, SC.CustomerID
  ORDER BY TotalInvoice ASC;


 

  





