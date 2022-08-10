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
    /// Interaction logic for ExpensePage.xaml
    /// </summary>
    public partial class ExpensePage : Page
    {
        public ExpensePage()
        {
            InitializeComponent();
            //Populate text boxes with any previously entered data
            if (MainWindow.groceries != 0 && MainWindow.waterLights != 0 && MainWindow.travel != 0 && MainWindow.phone != 0 && MainWindow.other != 0)
            {
                txbGroceries.Text = "" + MainWindow.groceries;
                txbWaterLights.Text = "" + MainWindow.waterLights;
                txbTravel.Text = "" + MainWindow.travel;
                txbPhone.Text = "" + MainWindow.phone;
                txbOther.Text = "" + MainWindow.other;
            }
            //Change selection color of button
            var window = (MainWindow)Application.Current.MainWindow;
            window.ResetSelections();
            window.btnExpenses.BorderBrush = (Brush)MainWindow.bc.ConvertFrom("#FF84A8FF");
            window.btnExpenses.BorderThickness = new Thickness(2);
        }

        private void btnExpenseSubmit_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            bool valid = true;
            //Makes sure expenseTotal doesn't compound if you repeatedly click submit
            MainWindow.expenseTotal -= (MainWindow.groceries + MainWindow.waterLights + MainWindow.travel + MainWindow.phone + MainWindow.other);

            if (!decimal.TryParse(txbGroceries.Text, out MainWindow.groceries))
            {
                valid = false;
                lblGroceriesError.Content = MainWindow.decMessage;
                txbGroceries.BorderBrush = Brushes.Red;
            }
            else
            {
                lblGroceriesError.Content = "";
                txbGroceries.BorderBrush = Brushes.Black;
            }
            //Start checking if expenses are over the limit
            if (!MainWindow.limitReached) { MainWindow.n(MainWindow.groceries); }

            if (!decimal.TryParse(txbWaterLights.Text, out MainWindow.waterLights))
            {
                valid = false;
                lblWaterLightsError.Content = MainWindow.decMessage;
                txbWaterLights.BorderBrush = Brushes.Red;
            }
            else
            {
                lblWaterLightsError.Content = "";
                txbWaterLights.BorderBrush = Brushes.Black;
            }
            if (!MainWindow.limitReached) { MainWindow.n(MainWindow.waterLights); }

            if (!decimal.TryParse(txbTravel.Text, out MainWindow.travel))
            {
                valid = false;
                lblTravelError.Content = MainWindow.decMessage;
                txbTravel.BorderBrush = Brushes.Red;
            }
            else
            {
                lblTravelError.Content = "";
                txbTravel.BorderBrush = Brushes.Black;
            }
            if (!MainWindow.limitReached) { MainWindow.n(MainWindow.travel); }

            if (!decimal.TryParse(txbPhone.Text, out MainWindow.phone))
            {
                valid = false;
                lblPhoneError.Content = MainWindow.decMessage;
                txbPhone.BorderBrush = Brushes.Red;
            }
            else
            {
                lblPhoneError.Content = "";
                txbPhone.BorderBrush = Brushes.Black;
            }
            if (!MainWindow.limitReached) { MainWindow.n(MainWindow.phone); }

            if (!decimal.TryParse(txbOther.Text, out MainWindow.other))
            {
                valid = false;
                lblOtherError.Content = MainWindow.decMessage;
                txbOther.BorderBrush = Brushes.Red;
            }
            else
            {
                lblOtherError.Content = "";
                txbOther.BorderBrush = Brushes.Black;
            }
            if (!MainWindow.limitReached) { MainWindow.n(MainWindow.other); }

            if (valid)
            {
                window.btnExpenses.Background = (Brush)MainWindow.bc.ConvertFrom("#FF7FFF7F");
                window.btnHome.IsEnabled = true;
                MessageBoxResult result = MessageBox.Show("Will you be renting your house? \n (Select No for buying with a loan)", "Home finance type", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result.Equals(MessageBoxResult.Yes))
                {
                    MainWindow.hl = null;
                    window.DataFrame.Content = new RentPage();
                }
                else
                {
                    MainWindow.r = null;
                    window.DataFrame.Content = new LoanPage();
                }
            }
            else
            {
                /* Brush Colour from:
                * https://stackoverflow.com/questions/979876/set-background-color-of-wpf-textbox-in-c-sharp-code
                * User answered:
                * https://stackoverflow.com/users/703717/danield
                * Accessed 29 June 2022*/
                window.btnExpenses.Background = (Brush)MainWindow.bc.ConvertFrom("#FFFF7F7F");
                window.btnHome.IsEnabled = false;
                window.btnVehicle.IsEnabled = false;
                window.btnReport.IsEnabled = false;
            }
        }
    }
}
