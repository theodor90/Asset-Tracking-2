using System;
using AssetTracking.Data;
using AssetTracking.Assets;

namespace AssetTracking.Services
{
    public class AddAssetService
    {
        // Method to add a new asset
        public void AddAsset()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Add Asset");
                Console.Write("Enter type (Laptop/MobilePhone): ");
                var type = Console.ReadLine();
                Console.Write("Enter brand: ");
                var brand = Console.ReadLine();
                Console.Write("Enter model name: ");
                var modelName = Console.ReadLine();
                Console.Write("Enter purchase date (yyyy-mm-dd): ");
                var purchaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter price: ");
                var price = double.Parse(Console.ReadLine());

                var assetManager = new AssetManager();

                // Add a new Laptop or MobilePhone based on user input
                if (type.Equals("Laptop", StringComparison.OrdinalIgnoreCase))
                {
                    assetManager.CreateAsset(new Laptop
                    {
                        Brand = brand,
                        ModelName = modelName,
                        PurchaseDate = purchaseDate,
                        Price = (int)(price) 
                    });
                }
                else if (type.Equals("MobilePhone", StringComparison.OrdinalIgnoreCase))
                {
                    assetManager.CreateAsset(new MobilePhone
                    {
                        Brand = brand,
                        ModelName = modelName,
                        PurchaseDate = purchaseDate,
                        Price = (int)(price) 
                    });
                }
                else
                {
                    Console.WriteLine("Invalid asset type.");
                }

                Console.WriteLine("Asset added successfully. Press any key to continue.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please try again. Press any key to continue.");
            }
            Console.ReadKey();
        }
    }
}
