using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinancesApp.Repository.IncomeRep
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext repositoryContext, IUnitOfWork unitOfWork) : base(repositoryContext, unitOfWork)
        {
        }

        public async Task<Income> CreateIncomes(Income income)
        {
           // var userInfo = await unitOfWork.UserInfo.GetUserInfoAsync(income.IncomeType.UserInfo.UserId);

            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == income.IncomeType.UserInfoId).FirstOrDefaultAsync();

            if (userInfo is null)
            {
                throw new Exception();
            }

            userInfo.Money += income.Amount;
            repositoryContext.Set<UserInfo>().Update(userInfo);
            
            
            Create(income);
            await unitOfWork.SaveAsync();
            return income;
        }

        public async Task DeleteIncome(int id)
        {

            var income = await FindByCondition(x => x.Id == id).Include(x => x.IncomeType).FirstOrDefaultAsync();

            if (income is null)
            {
                throw new Exception();
            }

            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == income.IncomeType.UserInfoId).FirstOrDefaultAsync();

            if (userInfo is null)
            {
                throw new Exception();
            }

            userInfo.Money -= income.Amount;

            repositoryContext.Set<UserInfo>().Update(userInfo);

            Delete(income);

            await unitOfWork.SaveAsync();
        }

        public async Task<Income> GetIncomeByID(int id)
        {
            var income = await FindByCondition(x => x.Id == id).Include(x =>x.IncomeType).FirstOrDefaultAsync();

            if (income is null)
            {
                throw new Exception();
            }

            return income;
        }

        public async Task<IEnumerable<Income>> GetIncomesByUserInfoID(int userInfoID)
        {

            var income = await FindByCondition(x => x.IncomeType.UserInfoId == userInfoID).Include(x => x.IncomeType).ToListAsync();

            if (income is not null)
            {
                return income;
            }

            throw new Exception();

    
        }

        public async Task<Income> UpdateIncome(Income income)
        {
            var incomeToUpdate = await GetIncomeByID(income.Id);

            var userInfo = await repositoryContext.Set<UserInfo>().Where(x => x.Id == incomeToUpdate.IncomeType.UserInfoId).FirstOrDefaultAsync();
            


            if (incomeToUpdate.Amount > income.Amount)
            {
                var difference = incomeToUpdate.Amount - income.Amount;
                userInfo.Money -= difference;
                incomeToUpdate.Amount -= difference;
            }
            if (incomeToUpdate.Amount < income.Amount)
            {
                var difference = (income.Amount - incomeToUpdate.Amount);
                userInfo.Money += difference;
                incomeToUpdate.Amount += difference;
            }

            repositoryContext.Set<UserInfo>().Update(userInfo);
            Update(incomeToUpdate);


            await unitOfWork.SaveAsync();
            return income;
        }
        public async Task<IEnumerable<Income>> GetAllIncomesByType(int incomeTypeId)
        {
            var incomes = await FindByCondition(x => x.IncomeTypeId == incomeTypeId).Include(x => x.IncomeType).ToListAsync();

            return incomes;
        }
        public async Task<List<IncomeTypeChart>> GetIncomeChart(int userInfoId)
        {
            var incomeTypes = await unitOfWork.IncomeType.GetIncomeTypes(userInfoId);

            var incomeTypeChart = new List<IncomeTypeChart>();



            foreach (var item in incomeTypes)
            {
                var incomes = await unitOfWork.Income.GetAllIncomesByType(item.Id);

                if (incomes is not null)
                {
                    incomeTypeChart.Add(new IncomeTypeChart(item.TypeName, incomes.Count()));
                }
            }

            return incomeTypeChart;
        }


    }
}