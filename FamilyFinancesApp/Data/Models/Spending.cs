using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class Spending : Operation
    {
        [Required]
        [Remote(action: "IsSpendingAmountValid", controller: "Spending", HttpMethod = "GET", ErrorMessage = "Amount cannot be bigger than account ammount")]
        public virtual decimal Amount { get; set; }

        [Required]
        public int SpendingTypeId { get; set; }

        public SpendingType? SpendingType { get; set; }
    }
}
