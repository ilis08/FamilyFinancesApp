using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }

        public Task<Income> CreateIncomes(Income income)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIncome(int income)
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetIncomeByID(int incomeID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Income>> GetIncomesByUserInfoID(int userInfoID)
        {
            throw new NotImplementedException();
        }

        public Task<Income> UpdateIncome(Income income)
        {
            throw new NotImplementedException();
        }
    }
}