namespace VarApp.Core.Models.Detailing
{
    public class ExportProp : IExportProp
    {
        public PropType Type { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
    }
}