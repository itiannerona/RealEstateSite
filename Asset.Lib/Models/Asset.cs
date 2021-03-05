using System;
using AssetsManagement.Inventory.Helpers;

namespace AssetsManagement.Inventory.Models
{
    public record Asset
    {
        public Asset() { }

        public Guid Id { get; init; }
        public Address Address { get; init; }
    }
}
