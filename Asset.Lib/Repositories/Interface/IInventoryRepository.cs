using AssetsManagement.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsManagement.Inventory.Repositories.Interface
{
    public interface IInventoryRepository
    {
        Task<Guid> AddAssetAsync(Asset property);
    }
}
