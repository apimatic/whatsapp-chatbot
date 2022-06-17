using System.Threading.Tasks;

namespace whatsapp_chatbot.Services
{
    public interface ICreateMessage
    {
        Task<string> GenerateCompletion(string prompt);
    }
}