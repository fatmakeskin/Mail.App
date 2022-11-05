using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.SendMailServices
{
    public interface ISendMailService
    {
        Task SendMailAsync(SendMailModel sendMailModel);
    }
}
