using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction
{
    public interface IAttachmentService
    {
        Task<string?> Upload(IFormFile file , string FolderName = "images");

        bool Delete(string filepath);
    }
}
