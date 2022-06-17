using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whatsapp_chatbot.Models;
using whatsapp_chatbot.Services;

namespace whatsapp_chatbot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        
        private readonly ILogger<ApiController> _logger;
        private readonly ISendMessage _sendMessage;
        private readonly ICreateMessage _createMessage; 
        private string _verifyToken ;

        public ApiController(
            ILogger<ApiController> logger,
            ISendMessage sendMessage, 
            ICreateMessage createMessage, 
            IConfiguration config
            )
        {
            _logger = logger;
            _sendMessage = sendMessage;
            _createMessage = createMessage;
            _verifyToken = config.GetValue<string>("WhatsappVerifyToken");
        }

     
        [HttpGet("SendMessage")]
        public string SendMessage()
        {
             _sendMessage.SendTemplateMessageAsync().GetAwaiter().GetResult();
            return "";
            //return _createMessage.GenerateCompletion("What is a good name for a horse").GetAwaiter().GetResult();

        }

        [HttpGet("webhook")]
        public ActionResult<string> GetWebhook(
            [FromQuery(Name = "hub.mode")] string hubMode,
            [FromQuery(Name = "hub.challenge")] int hubChallenge,
            [FromQuery(Name = "hub.verify_token")] string hubVerifyToken)
        {

            if (string.IsNullOrEmpty(hubMode) || string.IsNullOrEmpty(hubVerifyToken))
            {
                return BadRequest();
            }

            // Check the mode and token sent are correct
            if (hubMode.Equals("subscribe") && hubVerifyToken.Equals(_verifyToken))
            {
                // Respond with 200 OK and challenge token from the request
                Console.WriteLine("WEBHOOK_VERIFIED");
                return Ok(hubChallenge);
            }
            else
            {
                // Respond with '403 Forbidden' if verify tokens do not match
                return Forbid();
            }
        }
    

    [HttpPost("webhook")]
    public ActionResult PostWebhook([FromBody] NotificationPayload notification)
    {

        foreach (var entry in notification.EntryObject)
        {
            foreach (var change in entry.Changes ?? Enumerable.Empty<NotificationPayload.Change>())
            {
                foreach (var message in change.Value?.Messages ?? Enumerable.Empty<NotificationPayload.Message>())
                {
                    Console.WriteLine($"Message recieved from: " + message.From + "\n" + "Message: " + message.Text);

                    var response = GenerateResponse(change.Value.Contacts?.FirstOrDefault()?.Profile?.Name ?? "Whatsapp User", message.Text?.Body ?? "Hello");
                    SendMessage(response, message.From);
                }

            }

        }
        return Ok();
    }

    private string GenerateResponse(string sender, string message)
    {
            //return $"Thankyou " + sender + ", for saying " + message;
            return _createMessage.GenerateCompletion(message).GetAwaiter().GetResult();

        }

    private void SendMessage(string message, string recipient)
    {
        _sendMessage.SendTextMessageAsync(message, recipient).GetAwaiter().GetResult();

    }


    }
}
