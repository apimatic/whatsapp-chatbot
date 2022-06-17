using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using WhatsAppCloudAPI.Standard;
using WhatsAppCloudAPI.Standard.Models;
using WhatsAppCloudAPI.Standard.Controllers;
using WhatsAppCloudAPI.Standard.Utilities;
using WhatsAppCloudAPI.Standard.Exceptions;
using Microsoft.Extensions.Configuration;

namespace whatsapp_chatbot.Services
{
    public class SendMessage : ISendMessage
    {
        private WhatsAppCloudAPIClient _client;
        private string _phoneNumberID = "101110022633571";

        public SendMessage(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _client = new WhatsAppCloudAPIClient.Builder()
                                .AccessToken(config.GetValue<string>("WhatsappAccessToken"))
                                .HttpClientConfig(config => config.NumberOfRetries(0))
                                .Build();
        }


        public async Task SendTemplateMessageAsync()
        {
            
            MessagesController messagesController = _client.MessagesController;

            var body = new Message();
            body.MessagingProduct = "whatsapp";
            body.To = "923450520071";
            body.Template = new Template();
            body.Template.Name = "hello_world";
            body.Template.Language = new Language();
            body.Template.Language.Code = "en_US";
            body.Type = MessageTypeEnum.Template;

            try
            {
                SendMessageResponse result = await messagesController.SendMessageAsync(_phoneNumberID, body);
            }
            catch (ApiException e) { };

        }

        public async Task SendTextMessageAsync(string message, string recipient) 
        {
            MessagesController messagesController = _client.MessagesController;

            var body = new Message();
            body.MessagingProduct = "whatsapp";
            body.To = recipient;
            body.Type = MessageTypeEnum.Text;
            body.Text = new Text(message);

            try
            {
                SendMessageResponse result = await messagesController.SendMessageAsync(_phoneNumberID, body);
            }
            catch (ApiException e) { };

        }


    }
}