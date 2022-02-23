namespace FamilyFinancesApp.UnitOfWorkFolder
{

    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
        

    }
}
