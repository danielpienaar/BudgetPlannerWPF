using System;
using System.Collections.Generic;

namespace BudgetPlannerWPF.Code
{
    public abstract class Expense
    {
        /* Region code adapted from:
         * https://stackoverflow.com/questions/21940917/more-elegant-way-to-write-code-section-dividers-in-c
         * User answered:
         * https://stackoverflow.com/users/1715579/p-s-w-g
         * Accessed 9 May 2022 */
        #region Inherited Fields
        public decimal GrossIncome { get; set; }
        public decimal TaxDeduct { get; set; }
        //Expenses array
        public List<KeyValuePair<decimal, string>> namedExpenses;
        public decimal AvailableMoney { get; set; }
        #endregion

        #region Inherited Methods
        protected Expense(decimal gIncome, decimal tDeduct, decimal groceries, decimal waterLights, decimal travel, decimal phone, decimal other)
        {
            GrossIncome = gIncome;
            TaxDeduct = tDeduct;
            /* Key-Value pair list from:
             * https://stackoverflow.com/questions/18801466/key-value-pair-list
             * User answered:
             * https://stackoverflow.com/users/1906557/i4v
             * Accessed 3 June 2022 */
            namedExpenses = new List<KeyValuePair<decimal, string>>() {
                new KeyValuePair<decimal, string> (groceries, "Groceries: "),
                new KeyValuePair<decimal, string> (waterLights, "Water & Lights: "),
                new KeyValuePair<decimal, string> (travel, "Travel: "),
                new KeyValuePair<decimal, string> (phone, "Phone: "),
                new KeyValuePair<decimal, string> (other, "Other: ")
            };
        }
        /* Format code adapted from:
         * https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0
         * Accessed 9 May 2022 */
        public static string FormatPrice(decimal price) => "R" + string.Format("{0:N2}", price);
        public decimal GetExpenses()
        {
            //Return total of expenses in namedExpenses
            decimal total = 0;
            foreach (var item in namedExpenses)
            {
                total += item.Key;
            }
            return total;
        }
        #endregion

        #region Abstract methods
        protected abstract decimal CalculateAvailable();
        #endregion
    }
}
