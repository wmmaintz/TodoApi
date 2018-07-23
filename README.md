# TodoApi
Initial Creation

This solution creates a .NET Core Todo API:

API                     Description               Request body    Response body

======================= ========================= =============== ====================

GET /api/todo           Get all to-do items       None            Array of to-do items

GET /api/todo/{id}      Get an item by ID         None            To-do item

POST /api/todo          Add a new item            To-do item      To-do item

PUT /api/todo/{id}      Update an existing item   To-do item      None

DELETE /api/todo/{id}   Delete an item            None            None


The following diagram shows the basic design of the app.

The client submits a request and receives a response from the application. Within the 
application, there exists the controller, the model, and the data access layer. The 
request comes into the application's controller, and read/write operations occur 
between the controller and the data access layer. The model is serialized and returned 
to the client in the response.

The client is whatever consumes the web API (mobile app, browser, etc.). 
Postman was used as the client to test the app while under development.

The todo model is an object that represents the data in the app. Models are represented 
as C# classes, also known as Plain Old CLR Object (POCOs).

A controller is the object that handles HTTP requests and creates the HTTP response. This
app has a single controller.

This app doesn't use a persistent database, but rather stores to-do items in an in-memory 
database.
