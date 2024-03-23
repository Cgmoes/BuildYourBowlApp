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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// Count of the countbox
        /// </summary>
        public uint Count 
        {
            get 
            {
                return (uint)GetValue(CountProperty);
            }
            set 
            {
                SetValue(CountProperty, value);
            }
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox), new PropertyMetadata(1u));

        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the increment button of countbox
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e) 
        {
            if (Count < uint.MaxValue) Count++;
        }

        /// <summary>
        /// Handles the decrement button of countbox
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count > 0) 
            {
                Count--;
            }
        }
    }
}
