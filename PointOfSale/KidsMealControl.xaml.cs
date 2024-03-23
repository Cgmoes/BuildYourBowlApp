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
    /// Interaction logic for KidsMealControl.xaml
    /// </summary>
    public partial class KidsMealControl : UserControl
    {
        public KidsMealControl()
        {
            InitializeComponent();

            FryEditDisplay.DataContext = new Fries() { _size = BuildYourBowl.Data.Size.Kids};
            MilkEditDisplay.DataContext = new Milk() { _size = BuildYourBowl.Data.Size.Kids};
        }

        /// <summary>
        /// Handles the click events for radio buttons to display the correct side choice
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void SideRadioButtonCheck(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && b.IsChecked == true && DataContext is KidsMeal k) 
            {
                if (b.Name == "Fries") 
                {
                    FryEditDisplay.Visibility = Visibility.Visible;
                    RefriedBeansEditDisplay.Visibility = Visibility.Hidden;
                    StreetCornEditDisplay.Visibility = Visibility.Hidden;

                    k.SideChoice = new Fries();
                    FryEditDisplay.DataContext = k.SideChoice;
                }
                else if (b.Name == "RefriedBeans")
                {
                    FryEditDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansEditDisplay.Visibility = Visibility.Visible;
                    StreetCornEditDisplay.Visibility = Visibility.Hidden;

                    k.SideChoice = new RefriedBeans();
                    RefriedBeansEditDisplay.DataContext = k.SideChoice;
                }
                else if (b.Name == "StreetCorn")
                {
                    FryEditDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansEditDisplay.Visibility = Visibility.Hidden;
                    StreetCornEditDisplay.Visibility = Visibility.Visible;

                    k.SideChoice = new StreetCorn();
                    StreetCornEditDisplay.DataContext = k.SideChoice;
                }
            }
        }

        /// <summary>
        /// Handles the click events for radio buttons to display the correct side choice
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void DrinkRadioButtonCheck(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && b.IsChecked == true && DataContext is KidsMeal k)
            {
                if (b.Name == "Milk")
                {
                    MilkEditDisplay.Visibility = Visibility.Visible;
                    HorchataEditDisplay.Visibility = Visibility.Hidden;
                    AguaFrescaEditDisplay.Visibility = Visibility.Hidden;

                    k.DrinkChoice = new Milk();
                    MilkEditDisplay.DataContext = k.DrinkChoice;
                }
                else if (b.Name == "Horchata")
                {
                    MilkEditDisplay.Visibility = Visibility.Hidden;
                    HorchataEditDisplay.Visibility = Visibility.Visible;
                    AguaFrescaEditDisplay.Visibility = Visibility.Hidden;

                    k.DrinkChoice = new Horchata();
                    HorchataEditDisplay.DataContext = k.DrinkChoice;
                }
                else if (b.Name == "AguaFresca")
                {
                    MilkEditDisplay.Visibility = Visibility.Hidden;
                    HorchataEditDisplay.Visibility = Visibility.Hidden;
                    AguaFrescaEditDisplay.Visibility = Visibility.Visible;

                    k.DrinkChoice = new AguaFresca();
                    AguaFrescaEditDisplay.DataContext = k.DrinkChoice;
                }
            }
        }
    }
}
