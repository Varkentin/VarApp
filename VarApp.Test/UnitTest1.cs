using VarApp.Core.Contracts;
using VarApp.Core.Entity;
using VarApp.Core.Entity.Enums;
using VarApp.Services;

namespace VarApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var orders = new List<Order>();
            var props = new List<IExportProp>()
            {
                new ExportProp { Position = 1, Title = "Order_ID", Type = PropType.Order_ID},
                new ExportProp { Position = 2, Title = "Order_Name", Type = PropType.Order_Name},


            };
            for (int i = 0; i < 100; i++)
            {
                orders.Add(new Order { Id = i, Name = "Name_" + i });
            }


            var detailingService = new DetailingService();

            detailingService.FillTable(orders, props);
        }
    }
}