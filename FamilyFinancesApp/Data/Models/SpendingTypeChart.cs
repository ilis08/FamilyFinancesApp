namespace FamilyFinancesApp.Data.Models
{
    public class SpendingTypeChart
    {
        public SpendingTypeChart(string spendingTypeName, decimal spendingCount)
        {
            SpendingTypeName = spendingTypeName;
            SpendingCount = spendingCount;
        }

        public string SpendingTypeName { get; set; }

        public decimal SpendingCount { get; set; }
    }
}
