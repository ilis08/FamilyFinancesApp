using FamilyFinancesApp.Repository.IncomeRep;
using FamilyFinancesApp.Repository.SpendingRep;
using FamilyFinancesApp.Repository.UserInfoRep;

namespace FamilyFinancesApp.UnitOfWorkFolder
{

    public interface IUnitOfWork : IDisposable
    {
        public IncomeRepository Income { get; }
        public SpendingRepository Spending { get; }
        public UserInfoRepository UserInfo { get; }

        Task SaveAsync(); 
    }
}
