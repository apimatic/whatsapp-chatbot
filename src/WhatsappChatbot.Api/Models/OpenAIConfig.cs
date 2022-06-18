using System.Text.Json.Serialization;

namespace WhatsappChatbot.Api.Models;

public class OpenAIConfig
{
    [JsonPropertyName("AccessToken")] public string AccessToken { get; set; } = default!;

    [JsonPropertyName("Model")] public string Model { get; set; } = default!;

    [JsonPropertyName("MaxTokens")] public int MaxTokens { get; set; }
}