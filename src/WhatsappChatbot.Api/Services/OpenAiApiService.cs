using Microsoft.Extensions.Options;
using OpenAIAPI.Standard;
using OpenAIAPI.Standard.Exceptions;
using OpenAIAPI.Standard.Models;
using WhatsappChatbot.Api.Models;

namespace WhatsappChatbot.Api.Services;

public class OpenAiApiService : IOpenAiApiService
{
    private readonly OpenAIAPIClient _openAiApiClient;
    private readonly ILogger<OpenAiApiService> _logger;
    private readonly OpenAIConfig _openAIConfig;

    public OpenAiApiService(OpenAIAPIClient openAiApiClient, IOptions<OpenAIConfig> openAiConfigAccessor, ILogger<OpenAiApiService> logger)
    {
        _openAiApiClient = openAiApiClient;
        _logger = logger;
        _openAIConfig = openAiConfigAccessor.Value;
    }

    public async Task<string> CreateCompletion(string prompt)
    {
        try
        {
            var completionResponse =
                await _openAiApiClient.OpenAIController.CreateCompletionAsync(CreateRequest(prompt));

            _logger.LogInformation("Completions received {@Responses}", completionResponse.Choices);
            return completionResponse.Choices.RandomElement().Text;
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, "Unable to receive response from Open AI");
            throw;
        }
    }

    private CreateCompletionRequest CreateRequest(string prompt) =>
        new()
        {
            Model = _openAIConfig.Model,
            Prompt = prompt,
            MaxTokens = _openAIConfig.MaxTokens,
            Temperature = 0.5,
            TopP = 1,
            N = 1,
            Stream = false,
            Logprobs = 0,
            PresencePenalty = 1,
            BestOf = 1,
            Echo = false,
            FrequencyPenalty = 1
        };
}
