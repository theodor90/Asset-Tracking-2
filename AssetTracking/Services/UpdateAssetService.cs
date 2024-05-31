using System;
using System;
using System.Linq;
using AssetTracking.Data;
using AssetTracking.Assets;

namespace AssetTracking.Services
{
    public class UpdateAssetService
    {
        // Method to update an existing asset
        public void UpdateAsset()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Update Asset");
                Console.Write("Enter asset type (Laptop/MobilePhone): ");
                var type = Console.ReadLine();
                Console.Write("Enter asset ID to update: ");
                var id = int.Parse(Console.ReadLine());

                var assetManager = new AssetManager();
                Asset asset = null;

                // Retrieve the asset based on type and ID
                if (type.Equals("Laptop", StringComparison.OrdinalIgnoreCase))
                {
                    asset = assetManager.GetAssets().OfType<Laptop>().FirstOrDefault(a => a.Id == id);
                }
                else if (type.Equals("MobilePhone", StringComparison.OrdinalIgnoreCase))
                {
                    asset = assetManager.GetAssets().OfType<MobilePhone>().FirstOrDefault(a => a.Id == id);
                }
                else
                {
                    Console.WriteLine("Invalid asset type.");
                    return;
                }

                if (asset == null)
                {
                    Console.WriteLine("Asset not found. Press any key to continue.");
                    Console.ReadKey();
                    return;
                }

                // Prompt user for new values, leave blank to keep current values
                Console.Write("Enter new brand (leave blank to keep current): ");
                var brand = Console.ReadLine();
                Console.Write("Enter new model name (leave blank to keep current): ");
                var modelName = Console.ReadLine();
                Console.Write("Enter new purchase date (leave blank to keep current, yyyy-mm-dd): ");
                var purchaseDateStr = Console.ReadLine();
                Console.Write("Enter new price (leave blank to keep current): ");
                var priceStr = Console.ReadLine();

                // Update the asset with new values
                if (!string.IsNullOrEmpty(brand))
                {
                    asset.Brand = brand;
                }
                if (!string.IsNullOrEmpty(modelName))
                {
                    asset.ModelName = modelName;
                }
                if (DateTime.TryParse(purchaseDateStr, out var purchaseDate))
                {
                    asset.PurchaseDate = purchaseDate;
                }
                if (double.TryParse(priceStr, out var price))
                {
                    asset.Price = (int)(price);
                }

                assetManager.UpdateAsset(asset);

                Console.WriteLine("Asset updated successfully. Press any key to continue.");
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
