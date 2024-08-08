namespace MVCFinalProje.Infrastucre.DataAccess
{
    public interface IAsyncRepository
    {
        Task<int> SaveChangeAsync();
    }
}