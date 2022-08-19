using VarApp.Core.Contracts;
using VarApp.Core.Entity.Enums;

namespace VarApp.Core.Entity
{
    public class ExportProp : IExportProp
    {
        public PropType Type { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
    }
}