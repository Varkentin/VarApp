namespace VarApp.Core.Contracts
{
    public interface IDetailingServiceProvider
    {
        void GetWorkbook(List<IDetailingProp> props, Stream outputStream);
    }
    public interface IDetailingService
    {

    }
}