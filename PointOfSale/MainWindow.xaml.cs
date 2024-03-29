using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
            
            MenuItemSelection.MenuItemClicked += HandleMenuItemClick!;
            OrderSummary.EditItemClicked += HandleMenuItemClick!;
            OrderSummary.RemoveItemClicked += HandleBackToMenu!;
            PaymentControlDisplay.ReceiptPrintedEvent += NewOrder!;
        }

        /// <summary>
        /// Event handler to cancel the order and create a new one
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void NewOrder(object sender, RoutedEventArgs e)
        {
                DataContext = new Order();
                HideViews();
                MenuItemSelection.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Event handler to handle if back to menu was clicked
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleBackToMenu(object sender, RoutedEventArgs e)
        {
            HideViews();
            MenuItemSelection.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles when a menu item is clicked
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleMenuItemClick(object sender, CustomMenuEventArgs e)
        {
            if (e.MenuItem is Entree)
            {
                HideViews();
                EntreeEditDisplay.Visibility = Visibility.Visible;
                EntreeEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is Fries)
            {
                HideViews();
                FryEditDisplay.Visibility = Visibility.Visible;
                FryEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is RefriedBeans)
            {
                HideViews();
                RefriedBeansEditDisplay.Visibility = Visibility.Visible;
                RefriedBeansEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is StreetCorn)
            {
                HideViews();
                StreetCornEditDisplay.Visibility = Visibility.Visible;
                StreetCornEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is AguaFresca)
            {
                HideViews();
                AguaFrescaEditDisplay.Visibility = Visibility.Visible;
                AguaFrescaEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is Horchata)
            {
                HideViews();
                HorchataEditDisplay.Visibility = Visibility.Visible;
                HorchataEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is Milk)
            {
                HideViews();
                MilkEditDisplay.Visibility = Visibility.Visible;
                MilkEditDisplay.DataContext = e.MenuItem;
            }
            else if (e.MenuItem is KidsMeal k)
            {
                HideViews();
                KidsMealEditDisplay.Visibility = Visibility.Visible;
                KidsMealEditDisplay.DataContext = e.MenuItem;
                KidsMealEditDisplay.FryEditDisplay.DataContext = k.SideChoice;
                KidsMealEditDisplay.MilkEditDisplay.DataContext = k.DrinkChoice;

                if (k is SlidersMeal) KidsMealEditDisplay.SlidersCheeseCheckBox.Visibility = Visibility.Visible;
                else if (k is not SlidersMeal) KidsMealEditDisplay.SlidersCheeseCheckBox.Visibility = Visibility.Hidden;

                if (k.SideChoice is Fries) KidsMealEditDisplay.FriesButton.IsChecked = true;
                else if (k.SideChoice is RefriedBeans) KidsMealEditDisplay.RefriedBeansButton.IsChecked = true; 
                else if(k.SideChoice is StreetCorn) KidsMealEditDisplay.StreetCornButton.IsChecked = true;

                if(k.DrinkChoice is Milk) KidsMealEditDisplay.MilkButton.IsChecked = true;
                else if(k.DrinkChoice is Horchata) KidsMealEditDisplay.HorchataButton.IsChecked = true;
                else if(k.DrinkChoice is AguaFresca) KidsMealEditDisplay.AguaFrescaButton.IsChecked = true;
            }
        }

        /// <summary>
        /// Makes all local controls in row 0, column 0 hidden
        /// </summary>
        private void HideViews() 
        {
            MenuItemSelection.Visibility = Visibility.Hidden;
            EntreeEditDisplay.Visibility = Visibility.Hidden;
            FryEditDisplay.Visibility = Visibility.Hidden;
            RefriedBeansEditDisplay.Visibility = Visibility.Hidden;
            StreetCornEditDisplay.Visibility = Visibility.Hidden;
            AguaFrescaEditDisplay.Visibility = Visibility.Hidden;
            HorchataEditDisplay.Visibility = Visibility.Hidden;
            MilkEditDisplay.Visibility = Visibility.Hidden;
            KidsMealEditDisplay.Visibility = Visibility.Hidden;
            PaymentControlDisplay.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// shows the payment screen
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void ShowPaymentControl(object sender, RoutedEventArgs e)
        {
            HideViews();
            PaymentControlDisplay.Visibility = Visibility.Visible;
            Order order = (Order)DataContext;
            PaymentControlDisplay.DataContext = new PaymentViewModel(order);
        }
    }
}