using Chirp.Api.Database;

namespace Chirp.Api;

public static class ApplicationStartup
{
    public static async Task InitializeAsync(this WebApplication a)
    {
        await InitializeDatabaseAsync(a);
    }

    private static async Task InitializeDatabaseAsync(WebApplication a)
    {
        await a.Services.GetRequiredService<ICassandraContext>().Configure();
    }
}
