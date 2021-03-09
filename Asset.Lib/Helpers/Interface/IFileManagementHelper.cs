using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsManagement.Inventory.Helpers.Interface
{
    internal interface IFileManagementHelper
    {
        Task<string> SaveFile(IFormFile stream);
    }
}
