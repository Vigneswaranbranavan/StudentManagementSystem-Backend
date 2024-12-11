using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities.E_mail;

namespace StudentManagementSystem.Repository
{
    public class SendMailRepository(AppDbContext appDbContext)
    {
        public async Task<EmailTemplate> GetTemplate(EmailType emailTypes)
        {
            var template = appDbContext.EmailTemplates.Where(x => x.EmailType == emailTypes).FirstOrDefault();
            return template;
        }
    }
}
