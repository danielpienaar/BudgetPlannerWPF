using System;
using System.Linq;

namespace BudgetPlannerWPF.Code
{
    public class HomeLoan : Expense
    {
        #region Fields
        decimal interest;
        public decimal PurchasePrice { get; set; }
        public decimal Deposit { get; set; }
        public decimal Interest
        {
            get => interest;
            //Ask for interest as percentage, convert to decimal for calculations
            set => interest = value / 100;
        }
        public int RepayMonths { get; set; }
        public decimal MonthlyRepayment { private set; get; }
        #endregion

        #region Methods
        public HomeLoan(decimal pPrice, decimal deposit, decimal interest, int rMonths, decimal gIncome, decimal tDeduct, decimal groceries, decimal waterLights, decimal travel, decimal phone, decimal other) : base(gIncome, tDeduct, groceries, waterLights, travel, phone, other)
        {
            PurchasePrice = pPrice;
            Deposit = deposit;
            Interest = interest;
            RepayMonths = rMonths;
            AvailableMoney = CalculateAvailable();
        }
        private decimal CalculateMonthlyRepayment()
        {
            /* Calculation from:
             * https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
             * Accessed 10 May 2022 */
            decimal repayment = (PurchasePrice - Deposit) * (1 + Interest * (RepayMonths / 12));
            repayment /= RepayMonths;
            if (repayment > GrossIncome / 3)
            {
                Console.Write($"---\nWARNING: Approval of this home loan is unlikely. The monthly repayment is {FormatPrice(repayment)}, which is more than a third of your gross monthly income.\n---");
            }
            MonthlyRepayment = repayment;
            return repayment;
        }
        protected override decimal CalculateAvailable()
        {
            return GrossIncome - TaxDeduct - GetExpenses() - CalculateMonthlyRepayment();
        }
        #endregion
    }
}
