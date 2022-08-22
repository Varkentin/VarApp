using VarApp.Core.Models.Detailing;

namespace VarApp.Core.Contracts
{
    public interface IExportProp
    {
        PropType Type { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
    }
}