namespace BudgetPlannerWPF.Code
{
    public class Rent : Expense
    {
        #region Fields
        public decimal RentalAmount { get; set; }
        #endregion

        #region Methods
        public Rent(decimal rAmount, decimal gIncome, decimal tDeduct, decimal groceries, decimal waterLights, decimal travel, decimal phone, decimal other) : base(gIncome, tDeduct, groceries, waterLights, travel, phone, other)
        {
            RentalAmount = rAmount;
            AvailableMoney = CalculateAvailable();
        }
        protected override decimal CalculateAvailable()
        {
            return GrossIncome - TaxDeduct - GetExpenses() - RentalAmount;
        }
        #endregion
    }
}
