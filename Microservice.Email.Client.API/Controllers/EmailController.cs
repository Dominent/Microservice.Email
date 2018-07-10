namespace Microservice.Email.Client.API.Controllers
{
    using Microservice.Email.Client.API.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class EmailController: Controller
    {
        private IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        [HttpPost]
        public IActionResult CreateEmail([FromBody]EmailInfo emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._emailService.SendAsync(emailInfo);

            return Ok();
        }
    }
}
