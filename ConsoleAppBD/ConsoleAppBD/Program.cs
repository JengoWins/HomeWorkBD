// See https://aka.ms/new-console-template for more information
using ConsoleAppBD.BDConns;

Console.WriteLine("Hello, World!");

Select select = new Select();
//ODBC
select.CreateConnectODBC();
select.JodODBC();
Console.WriteLine();
select.CreateConnectOleDB();
select.JobOleDB();