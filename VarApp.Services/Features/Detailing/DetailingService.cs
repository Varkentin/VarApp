namespace VarApp.UseCases.Features.Detailing
{
    public class DetailingService : IDetailingService
    {
        private readonly IUserService _userService;
        private readonly ExcelPackage _package;
        private ExcelWorksheet _sheet;
        public DetailingService(IUserService userService)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage();
            _package.Workbook.Worksheets.Add("nameWorkbook");
            _sheet = _package.Workbook.Worksheets.First();
            _userService = userService;
        }

        public void GetWorkbook(string nameWorkbook)
        {
            _package.Workbook.Worksheets.Add(nameWorkbook);
            _sheet = _package.Workbook.Worksheets.First();
        }

        public void FillTable<TEntity>(List<TEntity> entities, List<IExportProp> props)
        {
            FillHeader(props);
            FillBody(entities, props);
            _package.SaveAs(new FileInfo(@"C:\Test_Projects\myworkbook.xlsx"));
            //  _package.SaveAs(outputStream);
        }

        private void FillHeader(List<IExportProp> props) => props.ForEach(p => _sheet.Cells[1, p.Position].Value = p.Title);

        private void FillBody<TEntity>(List<TEntity> entities, List<IExportProp> props)
        {
            int row = 2;
            foreach (var entity in entities)
            {
                FillRow(entity, props, row);
                row++;
            }
        }

        private void FillRow<TEntity>(TEntity entity, List<IExportProp> props, int row)
        {
            if (entity is User user) FillCells(user, props, row);
            else if (entity is Order order) FillCells(order, props, row);
        }

        private void FillCells(User user, List<IExportProp> props, int row)
            => props.ForEach(p =>
            {
                _sheet.Cells[row, p.Position].Value = _userPropsDict.TryGetValue(p.Type, out var foo)
                ? foo(user)
                : ComputedProp(p, user);
            });

        private void FillCells(Order order, List<IExportProp> props, int row)
            => props.ForEach(p =>
            {
                _sheet.Cells[row, p.Position].Value = _orderPropsDict.TryGetValue(p.Type, out var foo)
                ? foo(order)
                : ComputedProp(p, order);
            });

        private string ComputedProp(IExportProp prop, Order order)
             => prop.Type switch
             {
                 PropType.Order_ID => "",
                 _ => "none"
             };

        private string ComputedProp(IExportProp prop, User user)
             => prop.Type switch
             {
                 PropType.User_Custom_Prop => _userService.Todo() ?? "",
                 _ => "none"
             };


        private static readonly Dictionary<PropType, Func<Order, string>> _orderPropsDict = new()
        {
            { PropType.Order_ID, o => o.Id.ToString()},
            { PropType.Order_Name, o => o.Name},
        };

        private static readonly Dictionary<PropType, Func<User, string>> _userPropsDict = new()
        {
             { PropType.User_ID, u => u.Id.ToString()},
             { PropType.User_Name, u => u.Name},
        };
    }
}