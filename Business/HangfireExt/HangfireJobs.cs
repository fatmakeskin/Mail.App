using Business.Services.SendMailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangfire;
using System.Threading.Tasks;
using Data.Models;

namespace Business.HangfireExt
{
    public class HangfireJobs : IJobs
    {
        private ISendMailService sendMailService;
        public HangfireJobs(ISendMailService _sendMailService)
        {
            sendMailService = _sendMailService;
        }

        public void DelayedJob(SendMailModel mailModel)
        {
            Hangfire.BackgroundJob.Schedule(() =>
                       sendMailService.SendMailAsync(mailModel), TimeSpan.FromMinutes(1));
        }

        public void FireAndForget(SendMailModel mailModel)
        {
            Hangfire.BackgroundJob.Enqueue(() => sendMailService.SendMailAsync(mailModel));
        }
    }
}
