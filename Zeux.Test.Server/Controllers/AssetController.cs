using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zeux.Test.Models;
using Zeux.Test.Services;
using System.Linq;

namespace Zeux.Test.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        //async is not needed
        [HttpGet("[action]/{type}")]
        public Task<IEnumerable<Asset>> Get(string type)
        {
            var result = Task.FromResult(Enumerable.Empty<Asset>());
            if (string.IsNullOrWhiteSpace(type) || type.ToLower() == "all")
                result = _assetService.Get();
            else result = _assetService.Get(type);

            return result;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            var result = await _assetService.GetTypes();
            return result.ToArray();
        }
    }
}
