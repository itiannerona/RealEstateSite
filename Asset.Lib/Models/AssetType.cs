﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset.Inventory.Models
{
    public record AssetType
    {
        public AssetType()
        {
            
        }

        public int Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<Feature> Features { get; init; }
    }
}
