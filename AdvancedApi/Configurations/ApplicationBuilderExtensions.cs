using AdvancedApi.Middlewares;

namespace AdvancedApi.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
       => applicationBuilder.UseMiddleware<GlobalExceptionHandler>();
    }
}
