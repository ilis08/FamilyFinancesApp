using FamilyFinancesApp.Repository.IncomeRep;
using FamilyFinancesApp.Repository.IncomeTypeRep;
using FamilyFinancesApp.Repository.SpendingRep;
using FamilyFinancesApp.Repository.SpendingTypeRep;
using FamilyFinancesApp.Repository.UserInfoRep;

namespace FamilyFinancesApp.UnitOfWorkFolder
{

    public interface IUnitOfWork : IDisposable
    {
        public IncomeRepository Income { get; }
        public SpendingRepository Spending { get; }
        public UserInfoRepository UserInfo { get; }
        public IncomeTypeRepository IncomeType { get; }
        public SpendingTypeRepository SpendingType { get; }

        Task SaveAsync(); 
    }
}
