namespace Task1
{
    internal static class SqlStatements
    {
        public const string InsertDefaultCar = @"INSERT INTO [D:\SIARHEI_FRUNCHAK\SOURCE\REPOS\PART 3 TASK 1\PART-3\PART 2 TASK 1\APP_DATA\NORTHWND.MDF].[dbo].[CarsTable]
           ([CarID]
           ,[Brand]
           ,[Year]
           ,[FuelConsumption]
           ,[StartPrice])
        VALUES
           ('2'
		   ,'Audi'
		   ,2002
		   ,'3'
		   ,3500.00)";

        public const string DeleteDefaultCar = @"DELETE FROM [D:\SIARHEI_FRUNCHAK\SOURCE\REPOS\PART 3 TASK 1\PART-3\PART 2 TASK 1\APP_DATA\NORTHWND.MDF].[dbo].[CarsTable] WHERE CarID = 2";

        public const string SelectCar = @"SELECT * FROM [D:\SIARHEI_FRUNCHAK\SOURCE\REPOS\PART 3 TASK 1\PART-3\PART 2 TASK 1\APP_DATA\NORTHWND.MDF].[dbo].[CarsTable] WHERE CarID = 2";

        public const string UpdateCarPrice = @"UPDATE [D:\SIARHEI_FRUNCHAK\SOURCE\REPOS\PART 3 TASK 1\PART-3\PART 2 TASK 1\APP_DATA\NORTHWND.MDF].[dbo].[CarsTable] SET [StartPrice] = 10000 WHERE [CarID] = 2";

    }
}
