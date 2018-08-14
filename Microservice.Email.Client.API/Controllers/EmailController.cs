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
        public IActionResult SendTextEmail([FromBody]EmailInfo emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._emailService.SendTextAsync(emailInfo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(503, ex.Message);
            }

            return Ok(new { Message = "Successfully sent text email!"});
        }

        [HttpPost]
        [Route("html")]
        public IActionResult SendHtmlEmail([FromBody]EmailInfo emailInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._emailService.SendHtmlAsync(emailInfo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(503, ex.Message);
            }

            return Ok(new { Message = "Successfully sent HTML email!" });
        }
    }
}
