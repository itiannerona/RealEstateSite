using AssetsManagement.Inventory.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AssetsManagement.Inventory.DTO
{
    public record AssetDTO
    {
        public Address Address { get; init; }
        public int AssetTypeId { get; init; }
        public IEnumerable<Tuple<int, string>> FeatureValues { get; init; }
        public string Description { get; init; }
        public IEnumerable<IFormFile> FormFiles { get; init; }
        public IEnumerable<string> FileNames { get; init; }
    }
}
