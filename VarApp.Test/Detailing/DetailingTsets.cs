

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
            var props = new List<IExportProp>()
            {
                new ExportProp { Position = 1, Title = "User_ID", Type = PropType.User_ID},
                new ExportProp { Position = 2, Title = "User_Name", Type = PropType.User_Name},
                new ExportProp { Position = 3, Title = "User_Custom_Prop", Type = PropType.User_Custom_Prop},
            };

            for (int i = 0; i < 10000; i++)
            {
                user.Add(new User { Id = i, Name = "Name_" + i });
            }
            var detailingService = new DetailingService(_userService);
            detailingService.FillTable(user, props);

        }
    }
}