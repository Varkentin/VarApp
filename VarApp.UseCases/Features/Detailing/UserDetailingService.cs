namespace VarApp.UseCases.Features.Detailing
{
    public class UserDetailingService : IDetailingServiceProvider
    {
        private readonly IUserService _userService;
        private ExcelPackage _package;
        private ExcelWorksheet _sheet;

        public UserDetailingService(IUserService userService)
        {
            _userService = userService;
        }

        public void GetWorkbook(IReadOnlyCollection<DetailingProp> props, Stream outputStream)
        {
            var users = new List<User>();

            //FillTable(users, props.Select(p => new UserDetailingProp
            //{
            //    Position = p.Position,
            //    Title = p.Title,
            //    Type = ()p.Type
                

            //}));
            // _package.SaveAs(new FileInfo(@"C:\Test_Projects\myworkbook.xlsx"));
            // _package.SaveAs(outputStream);
        }

        public void FillTable(List<User> users, List<UserDetailingProp> props)
        {
            InitExcelPackage();
            FillHeader(props);
            FillBody(users, props);
        }

        private void InitExcelPackage()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage();
            _package.Workbook.Worksheets.Add("nameWorkbook");
            _sheet = _package.Workbook.Worksheets.First();
        }

        private void FillHeader(List<UserDetailingProp> props) => props.ForEach(p => _sheet.Cells[1, p.Position].Value = p.Title);

        private void FillBody(List<User> users, List<UserDetailingProp> props)
        {
            int row = 2;
            users.ForEach(u =>
            {
                FillRow(u, props, row);
                row++;
            });
        }

        private void FillRow(User user, List<UserDetailingProp> props, int row)
            => props.ForEach(p =>
            {
                _sheet.Cells[row, p.Position].Value = _userPropsDict.TryGetValue(p.Type, out var foo)
                ? foo(user)
                : ComputedProp(p.Type, user);
            });


        private string ComputedProp(UserPropType type, User user)
             => type switch
             {
                 UserPropType.User_Custom_Prop => _userService.Todo() ?? "",
                 _ => "none"
             };


        private static readonly Dictionary<UserPropType, Func<User, string>> _userPropsDict = new()
        {
             { UserPropType.User_ID, u => u.Id.ToString()},
             { UserPropType.User_Name, u => u.Name},
        };

    }
}
