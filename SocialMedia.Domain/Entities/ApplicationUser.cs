using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ImgPath { get; set; }

        
        public required string FirstName { get; set; }
    }
}
