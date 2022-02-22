using FamilyFinancesApp.Data.Models;

namespace FamilyFinancesApp.Repository.UserInfoRep
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoAsync();
    }
}
