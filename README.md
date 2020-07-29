# CQRSSample
A sample .Net core 3.1 API implementing CQRS  pattern using Mediatr.This sample uses SQL Server as the persistance layer with EFCore as the ORM. The API is split at the aplication layer into Commands and Queries. The command layer is used to issue commands such as AddBooks, RemoveBooks or UpdateBooks. These commands implement the HTTP verbs Post, Put, Delete and Patch.The Query layer is used to query the data store for queries such as GetAllBooks and GetBookByID. These queries implement the HTTP verb get.
Splitting the API into a Command vertical and a Query vertical helps optimize the write side seperately from the read side. Generally systems follow a "read many write once" paradigm and a generic optimization for both reads and writes is not ideal. On the read side the sample uses the same data store but in a real life application the data store can be split and optimized at the read and write sides. 

Quick Whiteboard
![CQRS Sample design](https://github.com/PradeepLoganathan/CQRSSample/blob/master/Whiteboard.png)
