using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssetsManagement.Identity.Helpers
{
    public static class JsonHelper
    {
        public static async Task<T> DeserializeFileAsync<T>(string filePath)
        {
            await using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
