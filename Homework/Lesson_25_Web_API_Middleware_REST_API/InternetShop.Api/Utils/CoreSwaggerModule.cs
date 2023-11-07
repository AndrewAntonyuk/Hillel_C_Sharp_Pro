namespace InternetShop.Api.Utils
{
    public static class CoreSwaggerModule
    {
        public static IApplicationBuilder UseSwaggerModify(this IApplicationBuilder builder)
        {
            WebApplication? app = builder as WebApplication;

            if (app?.Environment.IsDevelopment() ?? false)
            {
                builder.UseSwagger();
                builder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Shop API v1");
                    c.OAuthAppName("Shop API");
                });
            }

            return builder;
        }
    }
}
