using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.SpendingRep
{
    public interface ISpendingRepository
    {
        Task<Spending> GetSpendingAsync(int id);

        Task<IEnumerable<Spending>> GetAllSpendingsAsync(int spendingTypeId);

        Task<Spending> CreateSpendingAsync(Spending spending);

        Task<Spending> UpdateSpendingAsync(Spending spending);

        Task DeleteSpending(int id);
    }
}
