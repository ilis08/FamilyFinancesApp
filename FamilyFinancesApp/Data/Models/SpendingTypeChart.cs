namespace FamilyFinancesApp.Data.Models
{
    public class SpendingTypeChart
    {
        public SpendingTypeChart(string spendingTypeName, int spendingCount)
        {
            SpendingTypeName = spendingTypeName;
            SpendingCount = spendingCount;
        }

        public string SpendingTypeName { get; set; }

        public int SpendingCount { get; set; }
    }
}
