using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public interface IIncomeRepository
    {
        Task<Income> GetIncomeByID (int id);

        Task<IEnumerable<Income>> GetIncomesByUserInfoID(int userInfoID);

        Task<Income> CreateIncomes(Income income);
        Task<Income> UpdateIncome(Income income);

        Task DeleteIncome(int id);
      
    }
}
