namespace InternetShop.Api.Utils
{
    public static class CoreLoggerModule
    {
        public static IServiceCollection AddCoreLogger(this IServiceCollection services)
        {
            return services.AddLogging(x =>
                   {
                       x.AddConsole();
                       x.AddDebug();
                   });
        }
    }
}
