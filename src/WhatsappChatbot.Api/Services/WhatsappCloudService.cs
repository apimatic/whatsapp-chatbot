using Microsoft.Extensions.Options;
using WhatsappChatbot.Api.Models;
using WhatsAppCloudAPI.Standard;
using WhatsAppCloudAPI.Standard.Exceptions;
using WhatsAppCloudAPI.Standard.Models;

namespace WhatsappChatbot.Api.Services;

public class WhatsappCloudService : IWhatsappCloudService
{
    private readonly WhatsAppCloudAPIClient _whatsAppCloudAPIClient;
    private readonly ILogger<WhatsappCloudService> _logger;
    private readonly WhatsappConfig _whatsappConfig;

    public WhatsappCloudService(WhatsAppCloudAPIClient whatsAppCloudAPIClient, ILogger<WhatsappCloudService> logger, IOptions<WhatsappConfig> whatsappConfigAccessor)
    {
        _whatsAppCloudAPIClient = whatsAppCloudAPIClient;
        _logger = logger;
        _whatsappConfig = whatsappConfigAccessor.Value;
    }

    public async Task SendTextMessage(string message, string recipient)
    {
        var body = CreateMessage(message, recipient);
        try
        {
             await _whatsAppCloudAPIClient.MessagesController.SendMessageAsync(_whatsappConfig.PhoneNumber, body);
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, "Unable to receive response from Open AI");
            throw;
        }
    }

    public bool VerifyToken(string hubVerifyToken) => 
        hubVerifyToken == _whatsappConfig.VerifyToken;

    private static Message CreateMessage(string message, string recipient) =>
        new()
        {
            MessagingProduct = "whatsapp",
            To = recipient,
            Type = MessageTypeEnum.Text,
            Text = new Text(message)
        };
}
