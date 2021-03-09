using AssetsManagement.Inventory.Helpers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace AssetsManagement.Inventory.Helpers
{
    internal class FileManagementHelper : IFileManagementHelper
    {
        private readonly string _path;

        public FileManagementHelper(IConfiguration configuration)
        {
            _path = configuration["fileManagement:savePath"];
        }

        public async Task<string> SaveFile(IFormFile formFile)
        {
            string fileName = Path.GetRandomFileName();
            string filePath = Path.Combine(_path, Path.GetRandomFileName());
            using Stream stream = File.Create(filePath);
            await formFile.CopyToAsync(stream);
            return fileName;
        }
    }
}
