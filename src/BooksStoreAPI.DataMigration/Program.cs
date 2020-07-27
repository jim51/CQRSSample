using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Books.DataMigration
{
    class Program
    {
        static int Main(string[] args)
        {

            var connectionString =
                args.FirstOrDefault()
                ?? @"Server=localhost,1433; Database=BooksDB;User Id=sa; Password=password_01;";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgradeEngine =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            if (!upgradeEngine.IsUpgradeRequired())
            {
                Console.WriteLine("No database upgrades are needed");
                return 0;
            }

            Console.WriteLine("database upgrades are needed");
            foreach (var scripts in upgradeEngine.GetScriptsToExecute())
            {
                Console.WriteLine($"{scripts.Name} has to be deployed");
            }
            var result = upgradeEngine.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
                return 0;
            }




        }
    }
}
