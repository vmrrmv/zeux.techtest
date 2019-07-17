using System.Collections.Generic;
using System.Linq;
using Zeux.Test.Models;
using Zeux.Test.Server.Models;

namespace Zeux.Test.Repositories
{
    public class FakeContext
    {
        public FakeContext()
        {
            Users = (new List<User>
                {
                    new User { Login="admin", Password="admin", Role = "admin" },
                    new User { Login="user", Password="user", Role = "user" }
                }).AsQueryable();

            AssetTypes = (new List<AssetType>
                {
                    new AssetType() { Id = 1, Name = "Savings" },
                    new AssetType() { Id = 2, Name = "P2P" },
                    new AssetType() { Id = 3, Name = "Funds" }
                }).AsQueryable();

            var assetTypes = AssetTypes.ToList();
            // assets have renamed for angular pipe demo
            // assets indexes have cahnged for  sort demo
            Assets = (new List<Asset>
                {
                    new Asset() { Id = 1, Name = "bannana", Percent = 0.135m, Sum = 300m, Type = assetTypes[0] },
                    new Asset() { Id = 1, Name = "apple", Percent = 0.235m, Sum = 400m, Type = assetTypes[0] },
                    new Asset() { Id = 1, Name = "name of investment 4", Percent = 0.2m, Sum = 100m, Type = assetTypes[0] },
                    new Asset() { Id = 1, Name = "orange", Percent = 0.115m, Sum = 200m, Type = assetTypes[0] },
                    new Asset() { Id = 1, Name = "name of investment 5", Percent = 0.96m, Sum = 460m, Type = assetTypes[1] },
                    new Asset() { Id = 1, Name = "name of investment 6", Percent = 0.78m, Sum = 450m, Type = assetTypes[2] },
                    new Asset() { Id = 1, Name = "name of investment 7", Percent = 0.12m, Sum = 460m, Type = assetTypes[0] },
                    new Asset() { Id = 1, Name = "name of investment 8", Percent = 0.10m, Sum = 300m, Type = assetTypes[1] },
                    new Asset() { Id = 1, Name = "name of investment 9", Percent = 0.59m, Sum = 500m, Type = assetTypes[2] },
                    new Asset() { Id = 1, Name = "name of investment 10", Percent = 0.44m, Sum = 50m, Type = assetTypes[0] }
                }).AsQueryable();
        }

        public IQueryable<User> Users { get; }

        public IQueryable<AssetType> AssetTypes { get; }

        public IQueryable<Asset> Assets { get; }
    }
}
