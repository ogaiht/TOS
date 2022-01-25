using Microsoft.Extensions.DependencyInjection;
using TOS.Common.Serialization.Json;
using TOS.Common.Text;
using TOS.Common.Utils;

namespace TOS.Common
{
    public static class CommonExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services
                .AddTransient<IJsonSerializer, JsonSerializer>()
                .AddTransient<IEncodingHelper, EncodingHelper>()
                .AddTransient<IEqualityChecker, EqualityChecker>()
                .AddTransient<IExceptionHelper, ExceptionHelper>()
                .AddTransient<IDateTimeProvider, DateTimeProvider>();
        }
    }
}
