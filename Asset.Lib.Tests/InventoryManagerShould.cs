using Moq;
using Asset.Inventory.Models;
using Asset.Inventory.Repositories.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Asset.Inventory.Tests
{
    public class InventoryManagerShould
    {
        private readonly InventoryManager _sut; 

        public InventoryManagerShould()
        {
            Mock<IInventoryRepository> inventoryRepository = new();
            _sut = new InventoryManager(inventoryRepository.Object);
        }
    }
}
