using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }


        public void SendMessage(string to, string subject, string message)
        {
            //Log message
            _logger.LogInformation($"To: {to} Subject: {subject} Message: {message}");
        }
    }
}
