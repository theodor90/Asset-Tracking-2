using AssetTracking.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Services
{
    public class SortAndDisplayAssetsService
    {
        // Method to display a sorted list of assets
        public void SortAndDisplayAssets()
        {
            try
            {
                var manager = new AssetManager();
                var assets = manager.GetAssets().OrderBy(a => a.PurchaseDate).ToList();

                Console.Clear();
                Console.WriteLine("ID".PadRight(5) + "Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Purchase Date".PadRight(20) + "Price".PadRight(20));
                Console.WriteLine(new string('-', 105));

                // Method to display a sorted list of assets
                foreach (var asset in assets)
                {
                    var type = asset is Laptop ? "Laptop" : "MobilePhone";
                    var endOfLifeDate = asset.PurchaseDate.AddYears(3);
                    var color = ConsoleColor.White;

                    if ((endOfLifeDate - DateTime.Now).TotalDays <= 90)
                    {
                        color = ConsoleColor.Red;
                    }
                    else if ((endOfLifeDate - DateTime.Now).TotalDays <= 180)
                    {
                        color = ConsoleColor.Yellow;
                    }

                    Console.ForegroundColor = color;
                    Console.WriteLine(asset.Id.ToString().PadRight(5) + type.PadRight(20) + asset.Brand.PadRight(20) + asset.ModelName.PadRight(20) +
                                      asset.PurchaseDate.ToString("d").PadRight(20) + asset.Price.ToString("C").PadRight(20));
                    Console.ResetColor();
                }

                Console.WriteLine("Press any key to continue.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key to continue.");
            }
            Console.ReadKey();
        }
    }
}

