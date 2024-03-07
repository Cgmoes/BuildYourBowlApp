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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to add the name of the item selected to the list view
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void AddName(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button b)
            {
                if (b.Name == "CustomBowlButton") list.Add(new Bowl());
                else if (b.Name == "CustomNachosButton") list.Add(new Nacho());
                else if (b.Name == "FriesButton") list.Add(new Fries());
                else if (b.Name == "AguaFrescaButton") list.Add(new AguaFresca());
                else if (b.Name == "ChickenNuggetsButton") list.Add(new ChickenNuggetsMeal());
                else if (b.Name == "CarnitasButton") list.Add(new CarnitasBowl());
                else if (b.Name == "ChickenFajitaButton") list.Add(new ChickenFajitaNachos());
                else if (b.Name == "StreetCornButton") list.Add(new StreetCorn());
                else if (b.Name == "HorchataButton") list.Add(new Horchata());
                else if (b.Name == "CornDogBitesButton") list.Add(new CornDogBitesMeal());
                else if (b.Name == "GreenChickenButton") list.Add(new GreenChickenBowl());
                else if (b.Name == "ClassicButton") list.Add(new ClassicNachos());
                else if (b.Name == "RefriedBeansButton") list.Add(new RefriedBeans());
                else if (b.Name == "MilkButton") list.Add(new Milk());
                else if (b.Name == "SlidersButton") list.Add(new SlidersMeal());
                else if (b.Name == "SpicySteakButton") list.Add(new SpicySteakBowl());
            }
        }
    }
}
