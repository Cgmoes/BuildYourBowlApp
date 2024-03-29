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

        }

        /// <summary>
        /// Handles the click events for radio buttons to display the correct side choice
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void KidsSideChoice(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && b.IsChecked == true && DataContext is KidsMeal k) 
            {
                if (b.Name == "FriesButton") 
                {
                    if(k.SideChoice is not Fries) k.SideChoice = new Fries() { _size = BuildYourBowl.Data.Size.Kids };

                    FryEditDisplay.Visibility = Visibility.Visible;
                    RefriedBeansEditDisplay.Visibility = Visibility.Hidden;
                    StreetCornEditDisplay.Visibility = Visibility.Hidden;
                    FryEditDisplay.DataContext = k.SideChoice;
                }
                if (b.Name == "RefriedBeansButton") 
                {
                    if(k.SideChoice is not RefriedBeans) k.SideChoice = new RefriedBeans() { _size = BuildYourBowl.Data.Size.Kids };

                    FryEditDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansEditDisplay.Visibility = Visibility.Visible;
                    StreetCornEditDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansEditDisplay.DataContext = k.SideChoice;
                }
                if(b.Name == "StreetCornButton") 
                {
                    if(k.SideChoice is not StreetCorn) k.SideChoice = new StreetCorn() { _size = BuildYourBowl.Data.Size.Kids };

                    FryEditDisplay.Visibility = Visibility.Hidden;
                    RefriedBeansEditDisplay.Visibility = Visibility.Hidden;
                    StreetCornEditDisplay.Visibility = Visibility.Visible;
                    StreetCornEditDisplay.DataContext = k.SideChoice;
                }
            }
        }

        /// <summary>
        /// Handles the click events for radio buttons to display the correct side choice
        /// </summary>
        /// <param name="sender">the object signaling the event</param>
        /// <param name="e">information about the event</param>
        private void KidsDrinkChoice(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && b.IsChecked == true && DataContext is KidsMeal k)
            {
                if (b.Name == "MilkButton")
                {
                    if (k.DrinkChoice is not Milk) k.DrinkChoice = new Milk() { _size = BuildYourBowl.Data.Size.Kids };

                    MilkEditDisplay.Visibility = Visibility.Visible;
                    HorchataEditDisplay.Visibility = Visibility.Hidden;
                    AguaFrescaEditDisplay.Visibility = Visibility.Hidden;
                    MilkEditDisplay.DataContext = k.DrinkChoice;
                }
                else if (b.Name == "HorchataButton")
                {
                    if (k.DrinkChoice is not Horchata) k.DrinkChoice = new Horchata() { _size = BuildYourBowl.Data.Size.Kids };

                    MilkEditDisplay.Visibility = Visibility.Hidden;
                    HorchataEditDisplay.Visibility = Visibility.Visible;
                    AguaFrescaEditDisplay.Visibility = Visibility.Hidden;
                    HorchataEditDisplay.DataContext = k.DrinkChoice;
                }
                else if (b.Name == "AguaFrescaButton")
                {
                    if (k.DrinkChoice is not AguaFresca) k.DrinkChoice = new AguaFresca() { _size = BuildYourBowl.Data.Size.Kids };

                    MilkEditDisplay.Visibility = Visibility.Hidden;
                    HorchataEditDisplay.Visibility = Visibility.Hidden;
                    AguaFrescaEditDisplay.Visibility = Visibility.Visible;
                    AguaFrescaEditDisplay.DataContext = k.DrinkChoice;
                }
            }
        }
    }
}
