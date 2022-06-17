using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OpenAIAPI.Standard;
using OpenAIAPI.Standard.Models;
using OpenAIAPI.Standard.Controllers;
using OpenAIAPI.Standard.Utilities;
using OpenAIAPI.Standard.Exceptions;
using Microsoft.Extensions.Configuration;

namespace whatsapp_chatbot.Services
{
    public class CreateMessage : ICreateMessage
    {
        private OpenAIAPIClient _client;
        private string _model ;
        private int _maxTokens;

        public CreateMessage(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _client = new OpenAIAPIClient.Builder().AccessToken(config.GetValue<string>("OpenAIAccessToken")).Build();
            _model = config.GetValue<string>("OpenAIModel");
            _maxTokens = config.GetValue<int>("MaxTokens");
        }

        public async Task<string> GenerateCompletion(string prompt)
        {
            OpenAIController openAIController = _client.OpenAIController;

            var body = new CreateCompletionRequest();
            body.Model = _model;
            body.Prompt = prompt;
            body.MaxTokens = _maxTokens;
            body.Temperature = 0.5;
            body.TopP = 1;
            body.N = 1;
            body.Stream = false;
            body.Logprobs = 0;
            body.PresencePenalty = 1;
            body.BestOf = 1;
            body.Echo = false;
            body.FrequencyPenalty = 1;
            body.Logprobs = 0;
            body.Stream = false;
            

            try
            {
                CreateCompletionResponse result = await openAIController.CreateCompletionAsync(body);
                return result.Choices.FirstOrDefault().Text;
            }
            catch (ApiException e) 
            {
                return "";
            };

        }


    }
}
