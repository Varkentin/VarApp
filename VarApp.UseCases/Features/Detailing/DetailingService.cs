namespace VarApp.UseCases.Features.Detailing
{
    public class DetailingService : IDetailingService
    {
        private readonly IUserService _userService;
        public DetailingService(IUserService userService)
        {
            _userService = userService;
        }

        public void GetWorkbook(List<IDetailingProp> props, DetailingType type, Stream outputStream) 
            => GetProvider(type).GetWorkbook(props, outputStream);

        public IDetailingServiceProvider GetProvider(DetailingType type) => type switch
        {
            DetailingType.User => new UserDetailingService(_userService),
            DetailingType.Order => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };

    
    }
}