using System.Threading.Tasks;

namespace whatsapp_chatbot.Services
{
    public interface ISendMessage
    {
        Task SendTemplateMessageAsync();
        Task SendTextMessageAsync(string message, string recipient);
    }
}