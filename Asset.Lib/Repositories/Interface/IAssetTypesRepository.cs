using RealEstate.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Inventory.Repositories.Interface
{
    public interface IAssetTypesRepository
    {
        Task<bool> DoesTypeExist(string propertyTypeName);
        Task<AssetType> AddAssetTypeAsync(string newType, IEnumerable<string> distinctNewFeatures);
        Task<AssetType> GetAssetTypeByNameAsync(string typeName);
        Task AddAssetTypeAsync(AssetType assetType);
    }
}
