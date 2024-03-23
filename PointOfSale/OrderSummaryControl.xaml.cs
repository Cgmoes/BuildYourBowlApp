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
using BuildYourBowl.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public event EventHandler<CustomMenuEventArgs>? EditItemClicked;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to remove the item from the order
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button b)
            {
                IMenuItem item = (IMenuItem)b.DataContext;
                list.Remove(item);
            }
        }

        /// <summary>
        /// Event handler to add the name of the item selected to the list view
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void HandleEditClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b && b.DataContext is IMenuItem item) 
            {
                EditItemClicked?.Invoke(this, new CustomMenuEventArgs(item));
            }
        }
    }
}
