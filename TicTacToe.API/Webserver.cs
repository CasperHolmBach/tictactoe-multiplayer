using TicTacToe.API.Hubs;
using TicTacToe.API.Services;

namespace TicTacToe.API;

public class Webserver
{
    public void InitializeApp()
    {
        var builder = WebApplication.CreateBuilder();
        AddServices(builder);
        
        var app = builder.Build();
        ConfigureApp(app);
        
        app.Run();
    }

    private void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSignalR();
        builder.Services.AddSingleton<IBroadcasterService, BroadcasterService>();
        builder.Services.AddSingleton<SessionManager>();
    }
    
    private void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.MapHub<GameHub>("/Game");
        
        app.UseHttpsRedirection();
    }
}