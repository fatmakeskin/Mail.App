using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.HangfireExt
{
    public interface IJobs
    {
        void DelayedJob(SendMailModel sendMailModel);
        void FireAndForget(SendMailModel sendMailModel);
    }
}
