using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<MyHub>("/chat");

app.MapGet("/", () => "Hello World!");

app.Run();

class MyHub : Hub
{
    public async IAsyncEnumerable<DateTime> Streaming(
        CancellationToken cancellationToken
    )
    {
        yield return DateTime.Now;
        await Task.Delay(100, cancellationToken);
    }
}
