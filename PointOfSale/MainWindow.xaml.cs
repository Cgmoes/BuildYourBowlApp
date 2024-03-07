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
            }
        }
    }
}
