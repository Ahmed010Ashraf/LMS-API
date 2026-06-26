using Microsoft.AspNetCore.Http;
using ServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServicesImplementation
{
    public class AttachmentService : IAttachmentService
    {

        List<string> AllowedExtentions = new() { ".png", ".jpg", ".jpeg" };
        int MaxSize = 2*1024*1024;
        public async Task<string?> Upload(IFormFile file, string FolderName = "images" )
        {
            var extention = Path.GetExtension(file.FileName);
            if (!AllowedExtentions.Contains(extention))
            {
                return null;
            }


            if (file.Length > MaxSize) { 
             return null;
            }


            var folderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", FolderName);


            var newFileName = $"{Guid.NewGuid()}{extention}";

            var newFilePath = Path.Combine(folderName, newFileName);


             using var stream = new FileStream(newFilePath, FileMode.Create);

            await file.CopyToAsync(stream);

            return newFileName;

        }

        public bool Delete(string filepath)
        {
            if (File.Exists(filepath)) { 
                File.Delete(filepath);
                return true;
            }
            return false;
        }

    }
}
