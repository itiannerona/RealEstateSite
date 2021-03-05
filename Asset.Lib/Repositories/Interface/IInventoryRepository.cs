using Asset.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset.Inventory.Repositories.Interface
{
    public interface IInventoryRepository
    {
        void AddPropertyAsync(Asset property);
    }
}
