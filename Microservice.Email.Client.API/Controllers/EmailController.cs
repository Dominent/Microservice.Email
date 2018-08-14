namespace Microservice.Email.Client.API.Controllers
{
    using Microservice.Email.Client.API.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/email")]
    public class EmailController: Controller
    {
        private IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        [HttpPost]
        [Route("text")]
        public IActionResult SendTextEmail(
            [FromQuery]string username,
            [FromQuery]string password,
            [FromBody]EmailInfo emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._emailService.SendTextAsync(emailInfo, new EmailCredentials() {
                    Username = username,
                    Password = password
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(503, ex.Message);
            }

            return Ok(new { Message = "Successfully sent text email!"});
        }

        [HttpPost]
        [Route("html")]
        public IActionResult SendHtmlEmail(
            [FromQuery]string username,
            [FromQuery]string password,
            [FromBody]EmailInfo emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._emailService.SendHtmlAsync(emailInfo, new EmailCredentials()
                {
                    Username = username,
                    Password = password
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(503, ex.Message);
            }

            return Ok(new { Message = "Successfully sent HTML email!" });
        }
    }
}
