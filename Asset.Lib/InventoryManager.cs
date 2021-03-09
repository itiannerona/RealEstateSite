using AssetsManagement.Inventory.DTO;
using AssetsManagement.Inventory.Models;
using AssetsManagement.Inventory.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsManagement.Inventory
{
    public sealed class InventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly long _fileSizeLimit;

        public InventoryManager(IInventoryRepository inventoryRepository, IConfiguration config)
        {
            _inventoryRepository = inventoryRepository;

            _fileSizeLimit = long.Parse(config["fileManagement:fileSizeLimit"]);
        }

        public async Task<Guid> AddAssetAsync(AssetDTO newAssetDTO)
        {
            if (newAssetDTO.FormFiles is not null && newAssetDTO.FormFiles.Sum(f => f.Length) > _fileSizeLimit)
                throw new ArgumentException($"File size exceed current cofiguration limit. Current limit: {_fileSizeLimit} bytes", nameof(newAssetDTO.FormFiles));

            Asset newAsset = new()
            {
                Address = newAssetDTO.Address,
                Description = newAssetDTO.Description,
                Images = Array.Empty<string>()
            };

            return await _inventoryRepository.AddAssetAsync(newAsset);
        }
    }
}
