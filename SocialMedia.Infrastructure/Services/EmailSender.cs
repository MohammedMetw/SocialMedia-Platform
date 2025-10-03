using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // This is a dummy implementation.
            // In a real application, you would integrate with a service like SendGrid or SMTP.
            // For now, we do nothing and just return a completed task.
            return Task.CompletedTask;
        }
    }
}