

namespace VarApp.Test.Detailing
{
    public class DetailingTest
    {
        private readonly IUserService _userService;

        public DetailingTest(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public void FillTable_Test()
        {
            var user = new List<User>();
            var props = new List<UserDetailingProp>()
            {
                new UserDetailingProp { Position = 1, Title = "User_ID", Type = UserPropType.User_ID},
                new UserDetailingProp { Position = 2, Title = "User_Name", Type = UserPropType.User_Name},
                new UserDetailingProp { Position = 3, Title = "User_Custom_Prop", Type = UserPropType.User_Custom_Prop},
            };

            for (int i = 0; i < 10000; i++)
            {
                user.Add(new User { Id = i, Name = "Name_" + i });
            }
            var detailingService = new UserDetailingService(_userService);
            detailingService.FillTable(user, props);

        }
    }
}