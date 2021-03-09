using System;
using System.Collections.Generic;
using AssetsManagement.Inventory.Helpers;

namespace AssetsManagement.Inventory.Models
{
    public record Asset
    {
        public Asset() { }

        public Guid Id { get; init; }
        public Address Address { get; init; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
