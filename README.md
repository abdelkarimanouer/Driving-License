# Important: Read This Before Running the Project

To run the project, follow these steps:

### 1- Copy the file `DVLD.bak` from the `DataBase Of DVL` folder in the project to the `C:\` drive.  
### 2- Open SQL Server Management Studio (SSMS). If you don’t have it, download and install it first.  
### 3- Run the following query in SSMS to restore the database:  

   ```sql
   RESTORE DATABASE DVLD  
   FROM DISK = 'C:\DVLD.bak'
   ```

### 4- Once the database is restored, you can use the project.

# Note:
Make sure SQL Server is running and you have permissions to restore databases.
