using System;
using AssetTracking.Services;

class Program
{
    static void Main(string[] args)
    {
        // Ensure the database is created
        using (var context = new AssetTracking.Data.AssetContext())
        {
            context.Database.EnsureCreated();
        }

        // Main application loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Asset Tracking System");
            Console.WriteLine("1. Add Asset");
            Console.WriteLine("2. View Assets");
            Console.WriteLine("3. Update Asset");
            Console.WriteLine("4. Delete Asset");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            // Execute the appropriate service based on user input
            switch (choice)
            {
                case "1":
                    new AddAssetService().AddAsset();
                    break;
                case "2":
                    new SortAndDisplayAssetsService().SortAndDisplayAssets();
                    break;
                case "3":
                    new UpdateAssetService().UpdateAsset();
                    break;
                case "4":
                    new DeleteAssetService().DeleteAsset();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
