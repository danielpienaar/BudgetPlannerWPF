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
    /// Interaction logic for VehiclePage.xaml
    /// </summary>
    public partial class VehiclePage : Page
    {
        public VehiclePage()
        {
            InitializeComponent();
            //Populate text boxes with any previously entered data
            if (!MainWindow.model.Equals("") && !MainWindow.make.Equals("") && MainWindow.vPrice != 0 && MainWindow.vDeposit != 0 && MainWindow.vInterest != 0 && MainWindow.vInsurance != 0)
            {
                txbMake.Text = MainWindow.make;
                txbModel.Text = MainWindow.model;
                txbVehiclePrice.Text = "" + MainWindow.vPrice;
                txbVehicleDeposit.Text = "" + MainWindow.vDeposit;
                txbVehicleInterest.Text = "" + MainWindow.vInterest;
                txbVehicleInsurance.Text = "" + MainWindow.vInsurance;
            }
            //Change selection color of button
            var window = (MainWindow)Application.Current.MainWindow;
            window.ResetSelections();
            window.btnVehicle.BorderBrush = (Brush)MainWindow.bc.ConvertFrom("#FF84A8FF");
            window.btnVehicle.BorderThickness = new Thickness(2);
        }

        private void btnVehicleSubmit_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            bool valid = true;
            decimal vehicleExpense = 0;
            //Makes sure expenseTotal doesn't compound if you repeatedly click submit
            MainWindow.expenseTotal -= (vehicleExpense);

            if (string.IsNullOrWhiteSpace(txbMake.Text))
            {
                valid = false;
                lblMakeModelError.Content = MainWindow.strMessage;
                txbMake.BorderBrush = Brushes.Red;
            }
            else
            {
                MainWindow.make = txbMake.Text;
                lblMakeModelError.Content = "";
                txbMake.BorderBrush = Brushes.Black;
            }

            if (string.IsNullOrWhiteSpace(txbModel.Text))
            {
                valid = false;
                lblMakeModelError.Content = MainWindow.strMessage;
                txbModel.BorderBrush = Brushes.Red;
            }
            else
            {
                MainWindow.model = txbModel.Text;
                lblMakeModelError.Content = "";
                txbModel.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbVehiclePrice.Text, out MainWindow.vPrice))
            {
                valid = false;
                lblVehiclePriceError.Content = MainWindow.decMessage;
                txbVehiclePrice.BorderBrush = Brushes.Red;
            }
            else
            {
                lblVehiclePriceError.Content = "";
                txbVehiclePrice.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbVehicleDeposit.Text, out MainWindow.vDeposit))
            {
                valid = false;
                lblVehicleDepositError.Content = MainWindow.decMessage;
                txbVehicleDeposit.BorderBrush = Brushes.Red;
            }
            else
            {
                lblVehicleDepositError.Content = "";
                txbVehicleDeposit.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbVehicleInterest.Text, out MainWindow.vInterest))
            {
                valid = false;
                lblVehicleInterestError.Content = MainWindow.decMessage;
                txbVehicleInterest.BorderBrush = Brushes.Red;
            }
            else
            {
                lblVehicleInterestError.Content = "";
                txbVehicleInterest.BorderBrush = Brushes.Black;
            }

            if (!decimal.TryParse(txbVehicleInsurance.Text, out MainWindow.vInsurance))
            {
                valid = false;
                lblVehicleInsuranceError.Content = MainWindow.decMessage;
                txbVehicleInsurance.BorderBrush = Brushes.Red;
            }
            else
            {
                lblVehicleInsuranceError.Content = "";
                txbVehicleInsurance.BorderBrush = Brushes.Black;
            }

            if (valid)
            {
                MainWindow.v = new Vehicle(MainWindow.make, MainWindow.model, MainWindow.vPrice, MainWindow.vDeposit, MainWindow.vInterest, MainWindow.vInsurance);
                vehicleExpense = MainWindow.v.CalculateVehicleExpense();
                if (!MainWindow.limitReached) { MainWindow.n(vehicleExpense); }
                window.btnVehicle.Background = (Brush)MainWindow.bc.ConvertFrom("#FF7FFF7F");
                window.btnReport.IsEnabled = true;
                window.DataFrame.Content = new ReportPage();
            }
            else
            {
                /* Brush Colour from:
                * https://stackoverflow.com/questions/979876/set-background-color-of-wpf-textbox-in-c-sharp-code
                * User answered:
                * https://stackoverflow.com/users/703717/danield
                * Accessed 29 June 2022*/
                window.btnVehicle.Background = (Brush)MainWindow.bc.ConvertFrom("#FFFF7F7F");
                window.btnReport.IsEnabled = false;
            }
        }
    }
}
