using BudgetPlannerWPF.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetPlannerWPF
{
    /// <summary>
    /// Interaction logic for LoanPage.xaml
    /// </summary>
    public partial class LoanPage : Page
    {
        public LoanPage()
        {
            InitializeComponent();
            //Populate text boxes with any previously entered data
            if (MainWindow.pPrice != 0 && MainWindow.deposit != 0 && MainWindow.interest != 0 && MainWindow.rMonths != 0)
            {
                txbPropertyPurchase.Text = "" + MainWindow.pPrice;
                txbDeposit.Text = "" + MainWindow.deposit;
                txbInterest.Text = "" + MainWindow.interest;
                txbRepayMonths.Text = "" + MainWindow.rMonths;
            }
            //Change selection color of button
            var window = (MainWindow)Application.Current.MainWindow;
            window.ResetSelections();
            window.btnHome.BorderBrush = (Brush)MainWindow.bc.ConvertFrom("#FF84A8FF");
            window.btnHome.BorderThickness = new Thickness(2);
        }

        private void btnLoanSubmit_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            bool valid = true;
            //Makes sure expenseTotal doesn't compound if you repeatedly click submit
            decimal repay = 0;
            if (MainWindow.hl != null)
            {
                repay = MainWindow.hl.MonthlyRepayment;
            }
            MainWindow.expenseTotal -= repay;

            if (!decimal.TryParse(txbPropertyPurchase.Text, out MainWindow.pPrice))
            {
                valid = false;
                lblPropertyPurchaseError.Content = MainWindow.decMessage;
                txbPropertyPurchase.BorderBrush = Brushes.Red;
            }
            else
            {
                lblPropertyPurchaseError.Content = "";
                txbPropertyPurchase.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbDeposit.Text, out MainWindow.deposit))
            {
                valid = false;
                lblDepositError.Content = MainWindow.decMessage;
                txbDeposit.BorderBrush = Brushes.Red;
            }
            else
            {
                lblDepositError.Content = "";
                txbDeposit.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbInterest.Text, out MainWindow.interest))
            {
                valid = false;
                lblInterestError.Content = MainWindow.decMessage;
                txbInterest.BorderBrush = Brushes.Red;
            }
            else
            {
                lblInterestError.Content = "";
                txbInterest.BorderBrush = Brushes.Black;
            }

            if (!int.TryParse(txbRepayMonths.Text, out MainWindow.rMonths))
            {
                valid = false;
                lblRepayError.Content = "Input must contain numbers only.";
                txbRepayMonths.BorderBrush = Brushes.Red;
            } 
            else if(MainWindow.rMonths > 360 || MainWindow.rMonths < 240)
            {
                valid = false;
                lblRepayError.Content = "Input must be between 240 and 360.";
                txbRepayMonths.BorderBrush = Brushes.Red;
            }
            else
            {
                lblRepayError.Content = "";
                txbRepayMonths.BorderBrush = Brushes.Black;
            }

            if (valid)
            {
                MainWindow.hl = new HomeLoan(MainWindow.pPrice, MainWindow.deposit, MainWindow.interest, MainWindow.rMonths, MainWindow.gIncome, MainWindow.tDeduct, MainWindow.groceries, MainWindow.waterLights, MainWindow.travel, MainWindow.phone, MainWindow.other);
                if (!MainWindow.limitReached) { MainWindow.n(MainWindow.hl.MonthlyRepayment); }
                window.btnHome.Background = (Brush)MainWindow.bc.ConvertFrom("#FF7FFF7F");
                //Ask user if they want to buy a vehicle
                MessageBoxResult result = MessageBox.Show("Will you be buying a vehicle?", "Buy Vehicle", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.Equals(MessageBoxResult.Yes))
                {
                    window.btnVehicle.IsEnabled = true;
                    window.DataFrame.Content = new VehiclePage();
                }
                else
                {
                    window.btnReport.IsEnabled = true;
                    window.DataFrame.Content = new ReportPage();
                }
            }
            else
            {
                /* Brush Colour from:
                * https://stackoverflow.com/questions/979876/set-background-color-of-wpf-textbox-in-c-sharp-code
                * User answered:
                * https://stackoverflow.com/users/703717/danield
                * Accessed 29 June 2022*/
                window.btnHome.Background = (Brush)MainWindow.bc.ConvertFrom("#FFFF7F7F");
                window.btnVehicle.IsEnabled = false;
                window.btnReport.IsEnabled = false;
            }
        }
    }
}
