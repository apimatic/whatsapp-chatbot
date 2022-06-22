namespace WhatsappChatbot.Api.Services;

public interface IOpenAiApiService
{
    Task<string> CreateCompletion(string prompt);
}