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
        }

        /// <summary>
        /// Event handler to cancel the order and create a new one
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button b)
            {
                DataContext = new Order();
                HideViews();
                MenuItemSelection.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Event handler to handle if back to menu was clicked
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void HandleBackToMenu(object sender, RoutedEventArgs e)
        {
            HideViews();
            MenuItemSelection.Visibility = Visibility.Visible;
        }

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
            else if (e.MenuItem is KidsMeal)
            {
                HideViews();
                KidsMealEditDisplay.Visibility = Visibility.Visible;
                KidsMealEditDisplay.DataContext = e.MenuItem;
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
        }
    }
}