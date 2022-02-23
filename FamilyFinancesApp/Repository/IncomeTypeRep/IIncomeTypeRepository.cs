using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.IncomeTypeRep
{
    public interface IIncomeTypeRepository
    {
        Task<IncomeType> CreateIncomeTypeAsync();
    }
}
