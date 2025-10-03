using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Infrastructure.Persistence
{
    public class SocialMediaDbContext : IdentityDbContext<ApplicationUser>
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {
        }
    }
}
