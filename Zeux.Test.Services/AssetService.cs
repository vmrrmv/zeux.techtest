using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Repositories;

namespace Zeux.Test.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Asset>> Get()
        {
            var result = await _repository.Get();
            return GetSorted(result);
        }

        public async Task<IEnumerable<Asset>> Get(string type)
        {
            var result = await _repository.Get(type);
            return GetSorted(result);
        }

        // to avoid duplicate code
        private IEnumerable<Asset> GetSorted(IQueryable<Asset> result)
        {
            //get only with name for sorting 
            //calculated because it is not a data layer
            return result.Where(x => !string.IsNullOrEmpty(x.Name))
                    .OrderBy(x => x.Name[0]).ToArray();
        }

        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _repository.GetTypes();
        }
    }
}
