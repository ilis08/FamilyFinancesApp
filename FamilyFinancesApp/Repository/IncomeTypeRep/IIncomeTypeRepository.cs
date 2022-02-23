using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.IncomeTypeRep
{
    public interface IIncomeTypeRepository
    {
        Task<IncomeType> CreateIncomeTypeAsync(IncomeType incomeType, int userInfoId);

        Task<IncomeType> GetIncomeType(int id);
        Task<IEnumerable<IncomeType>> GetIncomeTypes(int userInfoId);
        Task<IncomeType> UpdateIncomeTypeAsync(IncomeType incomeType);
        Task DeleteIncomeTypeAsync(int id);

    }
}
