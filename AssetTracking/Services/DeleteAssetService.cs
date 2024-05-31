using System;
using System.Linq;
using AssetTracking.Data;
using AssetTracking.Assets;

namespace AssetTracking.Services
{
    public class DeleteAssetService
    {
        // Method to delete an existing asset
        public void DeleteAsset()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Delete Asset");
                Console.Write("Enter asset type (Laptop/MobilePhone): ");
                var type = Console.ReadLine();
                Console.Write("Enter asset ID to delete: ");
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

                // Delete the asset
                assetManager.DeleteAsset(asset.Id);

                Console.WriteLine("Asset deleted successfully. Press any key to continue.");
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
