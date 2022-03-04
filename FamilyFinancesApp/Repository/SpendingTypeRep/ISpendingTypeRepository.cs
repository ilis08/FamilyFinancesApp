using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.SpendingTypeRep
{
    public interface ISpendingTypeRepository
    {
        Task<SpendingType> GetSpendingTypeAsync(int id);

        Task<IEnumerable<SpendingType>> GetIncomeTypesAsync(int userInfoId);

        Task<SpendingType> CreateSpendingTypeAsync(SpendingType spendingType, int userInfoId);

        Task<SpendingType> UpdateSpendingTypeAsync(SpendingType spendingType);

        Task DeleteSpendingType(int id);
    }
}
