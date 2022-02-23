using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class SpendingType : OperationType
    {
        [Required]
        public int UserInfoId { get; set; }

        public UserInfo? UserInfo { get; set; }

        public IEnumerable<Spending>? Spendings { get; set; }
    }
}
