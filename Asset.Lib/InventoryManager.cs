using Asset.Inventory.Models;
using Asset.Inventory.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace Asset.Inventory
{
    public sealed class InventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryManager(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<bool> AddPropertyAsync(Asset property)
        {
            return true;
        }
    }
}
