Implementation of the sql server with the connection string
<add name="DBConnectionString"
    connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=UrlDb;Integrated Security=true"
    providerName="System.Data.SqlClient"/>
   
i.e the local sql express is given for persistance of database  in the web.config file

To Add Database Changes use migrations
Enable-Migrations
Add-Migration
Update-Database
    
