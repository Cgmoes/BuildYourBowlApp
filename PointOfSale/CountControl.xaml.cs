using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CountControl.xaml
    /// </summary>
    public partial class CountControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(int), typeof(CountControl), new PropertyMetadata(0));

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public CountControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click to subtract from the count
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e) 
        {
            Count--;
        }

        /// <summary>
        /// Handles click to add to the count
        /// </summary>
        /// <param name="sender">object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e) 
        {
            Count++;
        }
    }
}
