using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Repository.SpendingTypeRep
{
    public class SpendingTypeRepository : BaseRepository<SpendingType>, ISpendingTypeRepository
    {
        public SpendingTypeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }

        public async Task<SpendingType> CreateSpendingTypeAsync(SpendingType spendingType, int userInfoId)
        {
            spendingType.UserInfoId = userInfoId;

            Create(spendingType);

            await unitOfWork.SaveAsync();

            return spendingType;
        }

        public async Task DeleteSpendingType(int id)
        {
            var spendingType = await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (spendingType is not null)
            {
                Delete(spendingType);
            }

            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<SpendingType>> GetIncomeTypesAsync(int userInfoId)
        {
            var spendingTypes = await FindByCondition(x => x.UserInfoId == userInfoId).ToListAsync();

            if (spendingTypes is not null)
            {
                return spendingTypes;
            }

            throw new Exception();
        }

        public async Task<SpendingType> GetSpendingTypeAsync(int id)
        {
            var spendingType = await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (spendingType is not null)
            {
                return spendingType;
            }

            throw new Exception();
        }

        public async Task<SpendingType> UpdateSpendingTypeAsync(SpendingType spendingType)
        {
            Update(spendingType);

            await unitOfWork.SaveAsync();

            return spendingType;
        }
    }
}
