namespace VarApp.Core.Models.Detailing
{
    public enum DetailingType
    {
        User,
        Order
    }

    public record DetailingProp(string Type, int Position, string Title);
}