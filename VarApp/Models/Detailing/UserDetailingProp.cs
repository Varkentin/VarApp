namespace VarApp.Core.Models.Detailing
{
    public class UserDetailingProp : IDetailingProp
    {
        public UserPropType Type { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
    }
}