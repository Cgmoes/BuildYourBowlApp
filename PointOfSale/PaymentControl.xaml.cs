using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Schema;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }

        public event EventHandler<RoutedEventArgs>? ReceiptPrintedEvent;

        /// <summary>
        /// Prints the receipt to a file
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void PrintReceipt(object sender, RoutedEventArgs e)
        {
            PaymentViewModel view = (PaymentViewModel)DataContext;

            File.AppendAllText("receipts.txt", view.Receipt);

            MessageBox.Show("Receipt printed. Click OK to start a new order");

            ReceiptPrintedEvent?.Invoke(this, new RoutedEventArgs());
        }
    }
}
