using FamilyFinancesApp.Data;
using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.Repository.UserInfoRep;

namespace FamilyFinancesApp.Repository.UserInfoRep
{
    public class UserInfoRepository : BaseRepository<UserInfoRepository>, IUserInfoRepository
    {
        public UserInfoRepository(ApplicationDbContext _repositoryContext) : base(_repositoryContext)
        {
        }

        public Task<UserInfo> GetUserInfoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
