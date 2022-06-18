using OpenAIAPI.Standard;
using WhatsappChatbot.Api.Services;
using WhatsAppCloudAPI.Standard;
using Microsoft.AspNetCore.Mvc;
using WhatsappChatbot.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<WhatsappConfig>(builder.Configuration.GetSection("Whatsapp"));
builder.Services.Configure<OpenAIConfig>(builder.Configuration.GetSection("OpenAI"));

builder.Services.AddSingleton<OpenAIAPIClient>(_ =>
    new OpenAIAPIClient.Builder()
        .AccessToken(builder.Configuration.GetValue<string>("OpenAI:AccessToken"))
        .Build());

builder.Services.AddSingleton<WhatsAppCloudAPIClient>(_ =>
    new WhatsAppCloudAPIClient.Builder()
        .AccessToken(builder.Configuration.GetValue<string>("Whatsapp:AccessToken"))
        .HttpClientConfig(config => config.NumberOfRetries(0))
        .Build());

builder.Services.AddSingleton<IOpenAiApiService, OpenAiApiService>();
builder.Services.AddSingleton<IWhatsappCloudService, WhatsappCloudService>();

var app = builder.Build();

app.MapGet("api/Webhook", (
        [FromQuery(Name = "hub.mode")] string? hubMode,
        [FromQuery(Name = "hub.challenge")] int? hubChallenge,
        [FromQuery(Name = "hub.verify_token")] string? hubVerifyToken, IWhatsappCloudService whatsappCloudService)
    =>
{
    if (string.IsNullOrEmpty(hubMode) || string.IsNullOrEmpty(hubVerifyToken))
        return Results.BadRequest("hubMode or hubVerifyToken is empty");
    if (!hubMode.Equals("subscribe") || !whatsappCloudService.VerifyToken(hubVerifyToken))
        return Results.BadRequest("Unable to verify token");
    return Results.Ok(hubChallenge);
});


app.MapPost("api/Webhook", async (
        [FromBody] NotificationPayload notification,
        IWhatsappCloudService whatsappCloudService, IOpenAiApiService openAiApiService, ILogger<Program> logger)
    =>
{
    foreach (var message in notification.EntryObject.SelectMany(entry =>
                 entry.Changes.SelectMany(change => change.Value.Messages)))
    {
        logger.LogInformation("Received message from {@Message}", message);
        var responseText = await openAiApiService.CreateCompletion(message.Text.Body);
        await whatsappCloudService.SendTextMessage(responseText, message.From);
    }
});

app.Map("/", async (httpContext) =>
    await httpContext.Response.WriteAsync("APIMatic Whatsapp POC running\n" +
                                          "For more details Visit https://github.com/apimatic/whatsapp-chatbot"));

app.Run();