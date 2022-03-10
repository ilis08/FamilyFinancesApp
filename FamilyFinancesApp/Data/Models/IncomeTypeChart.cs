namespace FamilyFinancesApp.Data.Models
{
    public class IncomeTypeChart
    {
        public IncomeTypeChart(string incomeTypeName, int incomeCount)
        {
            IncomeTypeName = incomeTypeName;
            IncomeCount = incomeCount;
        }

        public string IncomeTypeName { get; set; }

        public int IncomeCount { get; set; }
    }
}
