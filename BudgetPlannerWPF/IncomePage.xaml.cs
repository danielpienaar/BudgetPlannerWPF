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
    /// Interaction logic for IncomePage.xaml
    /// </summary>
    public partial class IncomePage : Page
    {

        public IncomePage()
        {
            InitializeComponent();
            //Populate text boxes with any previously entered data
            if (MainWindow.gIncome != 0 && MainWindow.tDeduct != 0)
            {
                txbGrossIncome.Text = "" + MainWindow.gIncome;
                txbTax.Text = "" + MainWindow.tDeduct;
            }
            //Change selection color of button
            var window = (MainWindow)Application.Current.MainWindow;
            window.ResetSelections();
            window.btnIncome.BorderBrush = (Brush)MainWindow.bc.ConvertFrom("#FF84A8FF");
            window.btnIncome.BorderThickness = new Thickness(2);
        }

        private void btnIncomeSubmit_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            bool valid = true;

            //Reset limits
            if (MainWindow.expenseTotal != 0)
            {
                MainWindow.expenseTotal = 0;
                MainWindow.limitReached = false;
                MessageBox.Show("The limits for your expenses have been reset.", "Limits Reset", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (!decimal.TryParse(txbGrossIncome.Text, out MainWindow.gIncome))
            {
                valid = false;
                lblGrossIncomeError.Content = MainWindow.decMessage;
                txbGrossIncome.BorderBrush = Brushes.Red;
            }
            else
            {
                lblGrossIncomeError.Content = "";
                txbGrossIncome.BorderBrush = Brushes.Black;
            }
            if (!decimal.TryParse(txbTax.Text, out MainWindow.tDeduct))
            {
                valid = false;
                lblTaxError.Content = MainWindow.decMessage;
                txbTax.BorderBrush = Brushes.Red;
            }
            else if (MainWindow.tDeduct >= MainWindow.gIncome)
            {
                valid = false;
                lblTaxError.Content = "Cannot be larger than gross income.";
                txbTax.BorderBrush = Brushes.Red;
            }
            else
            {
                lblTaxError.Content = "";
                txbTax.BorderBrush = Brushes.Black;
            }
            MainWindow.limit = 0.75m * (MainWindow.gIncome - MainWindow.tDeduct);

            if (valid)
            {
                window.btnIncome.Background = (Brush)MainWindow.bc.ConvertFrom("#FF7FFF7F");
                window.btnExpenses.IsEnabled = true;
                window.DataFrame.Content = new ExpensePage();
            }
            else
            {
                /* Brush Colour from:
                * https://stackoverflow.com/questions/979876/set-background-color-of-wpf-textbox-in-c-sharp-code
                * User answered:
                * https://stackoverflow.com/users/703717/danield
                * Accessed 29 June 2022*/
                window.btnIncome.Background = (Brush)MainWindow.bc.ConvertFrom("#FFFF7F7F");
                window.btnExpenses.IsEnabled = false;
                window.btnHome.IsEnabled = false;
                window.btnVehicle.IsEnabled = false;
                window.btnReport.IsEnabled = false;
            }
            
        }
    }
}
