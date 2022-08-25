namespace VarApp.Core.Contracts
{
    public interface IDetailingServiceProvider
    {
        void GetWorkbook(IReadOnlyCollection<DetailingProp> props, Stream outputStream);
    }
    public interface IDetailingService
    {
        void GetWorkbook(DetailingType type, IReadOnlyCollection<DetailingProp> props, Stream outputStream);
    }
}