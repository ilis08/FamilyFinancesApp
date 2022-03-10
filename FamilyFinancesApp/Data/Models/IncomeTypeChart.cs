namespace FamilyFinancesApp.Data.Models
{
    public class IncomeTypeChart
    {
        public IncomeTypeChart(string incomeTypeName, decimal incomeAmount)
        {
            IncomeTypeName = incomeTypeName;
            IncomeCount = incomeAmount;
        }

        public string IncomeTypeName { get; set; }

        public decimal IncomeCount { get; set; }
    }
}
