# ERP Net Project

**Enterprise resource planning (ERP)** is the integrated management of main business processes, often in real time and mediated bu software and technology.
### This ERP Net
Is created as a final project of the It Academy, which contains 4 main modules in the internal management of employees, CRM, sales, and inventory which contains: product, categories, movements, storage, warehouses made by clients.
In each module the user can do differents CRUD operations
It contains the employee users who can have the admin role to create other users, and to carry out special procedures. All users can login and make orders.

### Used technology

* In Backend DotNet Core with c# language
* Entity Framework for Database persistance
* LINQ
* SQL Server Database
* Automapper is an object object mapper. Works transforming an input object of one type into an output object of a different type
* Repository Pattern to achive some objectives as: 
	* Using Generic Repository which are bridges netween data and operations that are in different domains
	* Increases the level of abstraction in code
	* Isolate the data layer to support unit testing
	* Access the data source from many locations and want to apply centrally managed, consistent access rules and logic
	* Improve the code's maintainability and readability by separating business logic from data or service access logic and reducing the amount of redundant code

* JWT For Authentication Login and Register
* Frontend developed with Angular 2

If you'd like to quote someone, use the > character before the line:

> Coffee. The finest organic suspension ever devised... I beat the Borg with it.
> - Developed by Geraldine Hernández Al Attrach