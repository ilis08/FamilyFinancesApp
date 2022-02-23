using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public class IncomeRepository : BaseRepository<IncomeRepository>, IIncomeRepository
    {


        public IncomeRepository(ApplicationDbContext _repositoryContext) : base(_repositoryContext)
        {
           

        }

        Task<Income>CreateIncomes(Income income) => repositoryContext.Set<Income>().Add(income);
    }
}
