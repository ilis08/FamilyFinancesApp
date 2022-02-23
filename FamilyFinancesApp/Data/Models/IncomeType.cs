using System.ComponentModel.DataAnnotations;

namespace FamilyFinancesApp.Data.Models
{
    public class IncomeType : OperationType
    {
        [Required]
        public int UserInfoId { get; set; }

        public UserInfo? UserInfo { get; set; }

        public IEnumerable<Income>? Incomes { get; set; }
    }
}
