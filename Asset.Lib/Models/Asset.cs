using System;
using Asset.Inventory.Helpers;

namespace Asset.Inventory.Models
{
    public record Asset
    {
        public Asset() { }

        public Guid Id { get; init; }
        public Address Address { get; init; }
    }
}
