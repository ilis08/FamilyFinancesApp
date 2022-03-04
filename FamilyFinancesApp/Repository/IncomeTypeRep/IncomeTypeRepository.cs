using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Repository.IncomeTypeRep
{
    public class IncomeTypeRepository : BaseRepository<IncomeType>, IIncomeTypeRepository
    {
        public IncomeTypeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }
        public async Task<IncomeType> CreateIncomeTypeAsync(IncomeType incomeType, int userInfoId)
        {
           incomeType.UserInfoId = userInfoId;
            Create(incomeType);
            await unitOfWork.SaveAsync();
            return incomeType;

        }
        public async Task<IncomeType> UpdateIncomeTypeAsync(IncomeType incomeType)
        {
         
            Update(incomeType);
            await unitOfWork.SaveAsync();
            return incomeType;
        }


        public async Task DeleteIncomeTypeAsync(int id)
        {
            var incomeType = await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
            if (incomeType is not null)
            {
                Delete(incomeType);
            }
            await unitOfWork.SaveAsync();
        }

        public async Task<IncomeType> GetIncomeType(int id)
        {
            var incomeType = await FindByCondition(x => x. Id == id ).FirstOrDefaultAsync();

            if (incomeType is null)
            {
                throw new Exception();
            }

            return incomeType;
        }
        public async Task<IEnumerable<IncomeType>> GetIncomeTypes(int userInfoId)
        {
            var incomeType = await FindByCondition(x => x.UserInfoId == userInfoId).ToListAsync();
            if (incomeType is not null)
            {
                return incomeType;
            }

         throw new Exception();
            
        }

    }
}
