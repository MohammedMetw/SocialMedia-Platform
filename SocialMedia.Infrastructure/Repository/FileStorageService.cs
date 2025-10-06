using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Interface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string subfolder)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", subfolder);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            Directory.CreateDirectory(uploadsFolder);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/images/{subfolder}/{uniqueFileName}";
        }
    }
}