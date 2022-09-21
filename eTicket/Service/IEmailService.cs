using eTicket.Models;
using System.Threading.Tasks;

namespace eTicket.Service
{
    public interface IEmailService
    {
      public Task SendEmailTemplate (UserEmailOptions userEmailOptions);
      // Task SendEmailTemplate(UserEmailOptions userEmailOptions);
        
    }
}