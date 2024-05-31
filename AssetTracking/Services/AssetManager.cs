using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AssetTracking.Data;
using AssetTracking.Assets;

public class AssetManager
{
    public void CreateAsset(Asset asset)
    {
        using (var context = new AssetContext())
        {
            context.Add(asset);
            context.SaveChanges();
        }
    }

    public List<Asset> GetAssets()
    {
        using (var context = new AssetContext())
        {
            var laptops = context.Laptops.ToList();
            var mobilePhones = context.MobilePhones.ToList();

            return laptops.Cast<Asset>().Concat(mobilePhones).ToList();
        }
    }

    public void UpdateAsset(Asset asset)
    {
        using (var context = new AssetContext())
        {
            context.Update(asset);
            context.SaveChanges();
        }
    }

    public void DeleteAsset(int id)
    {
        using (var context = new AssetContext())
        {
            var asset = context.Laptops.Find(id) as Asset ?? context.MobilePhones.Find(id);
            if (asset != null)
            {
                context.Remove(asset);
                context.SaveChanges();
            }
        }
    }
}
