using Business.Services.SendMailServices;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendMailService mailService;
        public EmailController(ISendMailService _mailService)
        {
            mailService = _mailService;
        }
        [HttpPost("Send")]
        public async Task<IActionResult> Send(SendMailModel mailModel)
        {
            try
            {
                await mailService.SendMailAsync(mailModel);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
