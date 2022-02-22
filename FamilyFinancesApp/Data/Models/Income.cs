using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinancesApp.Data.Models
{
    public class Income : Operation
    {
        public int IncomeTypeId { get; set; }

        public IncomeType? IncomeType { get; set; }
    }
}
