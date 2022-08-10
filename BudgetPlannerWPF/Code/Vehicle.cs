namespace BudgetPlannerWPF.Code
{
    public class Vehicle
    {
        #region Fields
        private const int repayYears = 5;
        private decimal interest;
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public decimal Interest
        {
            get => interest;
            //Ask for interest as percentage, convert to decimal for calculations
            set => interest = value / 100;
        }
        public decimal Insurance { get; set; }
        #endregion

        #region Methods
        public Vehicle(string make, string model, decimal price, decimal deposit, decimal interest, decimal insurance)
        {
            Make = make;
            Model = model;
            Price = price;
            Deposit = deposit;
            Interest = interest;
            Insurance = insurance;
        }

        public decimal CalculateVehicleExpense()
        {
            decimal vExpense;
            /* Calculation from:
             * https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
             * Accessed 10 May 2022 */
            vExpense = (Price - Deposit) * (1 + Interest * repayYears);
            vExpense /= repayYears * 12;
            vExpense += Insurance;

            return vExpense;
        }
        #endregion
    }
}
