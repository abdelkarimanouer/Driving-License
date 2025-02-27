# Important: Read This Before Running the Project

To run the project, follow these steps:

### 1- Copy the file `DVLD.bak` from the `DataBase` folder in the project to the `C:\` drive.  
### 2- Open SQL Server Management Studio (SSMS). If you don’t have it, download and install it first.  
### 3- Run the following query in SSMS to restore the database:   


   RESTORE DATABASE DVLD  
   FROM DISK = 'C:\DVLD.bak'
  

### 4- After restoring the database, open the `DVL.exe` file located in the `\DVL\bin\Release` folder to run the application.

# Note:
Make sure SQL Server is running and you have permissions to restore databases.
