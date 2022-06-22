namespace WhatsappChatbot.Api.Services;

public interface IWhatsappCloudService
{
    Task SendTextMessage(string message, string response);
    
    bool VerifyToken(string hubVerifyToken);
}