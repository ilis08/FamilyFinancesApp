namespace FamilyFinancesApp.Data.Models
{
    public class IncomeType : OperationType
    {
        public IEnumerable<Income>? Incomes { get; set; }
    }
}
