using Dima.Core;

namespace Dima.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionStrings= builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

    }
}