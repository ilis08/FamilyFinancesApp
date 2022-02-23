using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class Income : Operation
    {
        [Required]
        public int IncomeTypeId { get; set; }

        public IncomeType? IncomeType { get; set; }
    }
}
