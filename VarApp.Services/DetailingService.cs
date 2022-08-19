using VarApp.Core.Contracts;
using VarApp.Core.Entity;
using VarApp.Core.Entity.Enums;
using OfficeOpenXml;

namespace VarApp.Services
{
    public class DetailingService : IDetailingService
    {
        private readonly ExcelPackage _package;
        private readonly ExcelWorksheet _sheet;
        public DetailingService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage();
            _package.Workbook.Worksheets.Add("Orders");
            _sheet = _package.Workbook.Worksheets.First();
        }

        public void FillTable<TEntity>(List<TEntity> entities, List<IExportProp> props)
        {
            FillHeader(props);
            FillBody(entities, props);
          //  _package.SaveAs(outputStream);
        }

        private void FillHeader(List<IExportProp> props) => props.ForEach(p => _sheet.Cells[1, p.Position].Value = p.Title);

        private void FillBody<TEntity>(List<TEntity> entities, List<IExportProp> props)
        {
            int row = 2;
            foreach (var entity in entities)
            {
                FillRow(entity, props, row);
                row += 2;
            }
        }

        private void FillRow<TEntity>(TEntity entity, List<IExportProp> props, int row)
        {
            if (entity is User user) FillUserProps(user, props, row);
            else if (entity is Order order) FillOrderProps(order, props, row);
        }

        private void FillUserProps(User user, List<IExportProp> props, int row)
            => props.ForEach(p =>
            {
                _sheet.Cells[row, p.Position].Value = UserPropsDict.TryGetValue(p.Type, out var foo)
                ? foo(user)
                : ComputedProp(p, user);
            });

        private void FillOrderProps(Order order, List<IExportProp> props, int row)
            => props.ForEach(p =>
            {
                _sheet.Cells[row, p.Position].Value = OrderPropsDict.TryGetValue(p.Type, out var foo)
                ? foo(order)
                : ComputedProp(p, order);
            });

        private string ComputedProp(IExportProp prop, Order order)
             => prop.Type switch
             {
                 PropType.Order_ID => "",
             };

        private string ComputedProp(IExportProp prop, User user)
             => prop.Type switch
             {
                 PropType.User_Name => "",
             };


        private static readonly Dictionary<PropType, Func<Order, string>> OrderPropsDict = new()
        {
            { PropType.Order_ID, (o) => o.Id.ToString()},
            { PropType.Order_Name, (o) => o.Name},
        };

        private static readonly Dictionary<PropType, Func<User, string>> UserPropsDict = new()
        {
             { PropType.User_ID, (u) => u.Id.ToString()},
             { PropType.User_Name, (u) => u.Name},
        };
    }
}