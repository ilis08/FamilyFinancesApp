using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;

namespace FamilyFinancesApp.Repository.IncomeTypeRep
{
    public class IncomeTypeRepository : BaseRepository<IncomeType>
    {
        public IncomeTypeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }


    }
}
