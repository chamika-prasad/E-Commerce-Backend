# E-Commerce-Backend

This is a simple Web-API for managing some functions of an e-commerce site.

## Tech Stack


**Server:** MsSQL Express

**Web API:** .NET 7.0




## Installation / Tools

 - [ASP.NET Web API](https://dotnet.microsoft.com/en-us/download)
 - [SQL Server 2022 Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
 - [VS 2022](https://visualstudio.microsoft.com/vs/community/)


## Install the Project



```bash
Open Visual Studio Community Edition 2022 and click on 'clone a repository'.
Then paste the project link and click clone.
```
    
## Start Project

Click the build and run button, and then Swagger Editor will pop up in the browser.


## Key Features 

There are two types of users in the system. They are User and Admin

1.	Customers can do the user registration using the system
2.	Admin added through the DB (no registration needed, direct insert)
3.	Admin can create/update/delete Product Categories and Product
4.	The customer can login to the system.
5.	Customers can search Products (search products by name/ category
6.	Customers can place Orderss


## Usage

-First Customer will register in the system.

-Customer will log in to the system.

-A JWT token will generate and store in the database when a user login to the system.

-JWT tokens are used to achieve authentication and authorization.

-Customers can view all products, search for a product by product name or category name and place orders.

-Admin is added through the DB.

-Admin will log in to the system.

-Admin can view/create/update/delete Product Categories and Products

-Admin can view all orders and updare order state.
