using System.Text.Json.Serialization;

namespace WhatsappChatbot.Api.Models;

public class WhatsappConfig
{
    [JsonPropertyName("AccessToken")] public string AccessToken { get; set; } = default!;

    [JsonPropertyName("PhoneNumber")] public string PhoneNumber { get; set; } = default!;

    [JsonPropertyName("VerifyToken")] public string VerifyToken { get; set; } = default!;
}