using RealEstate.Inventory.Models;
using RealEstate.Inventory.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Inventory
{
    public sealed class AssetTypesManager
    {
        private readonly IAssetTypesRepository _propertyTypesRepository;

        public AssetTypesManager(IAssetTypesRepository propertyTypesRepository)
        {
            _propertyTypesRepository = propertyTypesRepository;
        }

        public async Task<bool> DoesTypeExist(string typeName) 
            => await _propertyTypesRepository.DoesTypeExist(typeName);

        public async Task<AssetType> AddAssetTypeAsync(string newType, IEnumerable<string> newFeatures)
        {
            if (await _propertyTypesRepository.DoesTypeExist(newType) is true)
                return null;

            var distinctNewFeatures = newFeatures.Distinct();
            return await _propertyTypesRepository.AddAssetTypeAsync(newType, distinctNewFeatures);
        }

        public async Task<AssetType> GetAssetTypeByNameAsync(string typeName)
        {
            return await _propertyTypesRepository.GetAssetTypeByNameAsync(typeName);
        }
    }
}
