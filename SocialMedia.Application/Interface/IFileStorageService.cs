using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace SocialMedia.Application.Interface
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string subfolder);
    }
}
