namespace WhatsappChatbot.Api.Services;

public static class CollectionExtension
{
    private static readonly Random Rng = new();

    public static T RandomElement<T>(this IList<T> list) => list[Rng.Next(list.Count)];
}