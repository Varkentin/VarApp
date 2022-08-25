using VarApp.Core.Contracts;
using VarApp.Core.Contracts.Users;
using VarApp.UseCases.Features.Detailing;
using VarApp.UseCases.Features.Users;

namespace VarApp.Api.AppStart
{
    public partial class DependencyContainer
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDetailingService, DetailingService>();

        }
    }
}
