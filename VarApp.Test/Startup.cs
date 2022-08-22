using VarApp.UseCases.Features.Users;

namespace VarApp.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
