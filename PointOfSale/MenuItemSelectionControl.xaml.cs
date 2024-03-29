using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        public event EventHandler<CustomMenuEventArgs>? MenuItemClicked;

        /// <summary>
        /// Event handler to add the name of the item selected to the list view
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">information about the event</param>
        private void HandleButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list && sender is Button b)
            {
                if (b.Name == "CustomBowlButton")
                {
                    Bowl bowl = new Bowl();
                    list.Add(bowl);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(bowl));
                }
                else if (b.Name == "CustomNachosButton")
                {
                    Nacho n = new Nacho();
                    list.Add(n);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(n));
                }
                else if (b.Name == "FriesButton")
                {
                    Fries f = new Fries();
                    list.Add(f);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(f));
                }
                else if (b.Name == "AguaFrescaButton")
                {
                    AguaFresca af = new AguaFresca();
                    list.Add(af);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(af));
                }
                else if (b.Name == "CarnitasButton")
                {
                    CarnitasBowl cb = new CarnitasBowl();
                    list.Add(cb);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(cb));
                }
                else if (b.Name == "ChickenFajitaButton")
                {
                    ChickenFajitaNachos cfn = new ChickenFajitaNachos();
                    list.Add(cfn);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(cfn));
                }
                else if (b.Name == "StreetCornButton")
                {
                    StreetCorn sc = new StreetCorn();
                    list.Add(sc);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(sc));
                }
                else if (b.Name == "HorchataButton") 
                {
                    Horchata h = new Horchata();
                    list.Add(h);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(h));
                }
                else if (b.Name == "GreenChickenButton")
                {
                    GreenChickenBowl gcb = new GreenChickenBowl();
                    list.Add(gcb);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(gcb));
                }
                else if (b.Name == "ClassicButton")
                {
                    ClassicNachos cNachos = new ClassicNachos();
                    list.Add(cNachos);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(cNachos));
                }
                else if (b.Name == "RefriedBeansButton")
                {
                    RefriedBeans beans = new RefriedBeans();
                    list.Add(beans);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(beans));
                }
                else if (b.Name == "MilkButton")
                {
                    Milk milk = new Milk();
                    list.Add(milk);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(milk));
                }
                else if (b.Name == "ChickenNuggetsButton")
                {
                    ChickenNuggetsMeal cnm = new ChickenNuggetsMeal();
                    list.Add(cnm);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(cnm));
                }
                else if (b.Name == "CornDogBitesButton")
                {
                    CornDogBitesMeal cdb = new CornDogBitesMeal();
                    list.Add(cdb);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(cdb));
                }
                else if (b.Name == "SlidersButton")
                {
                    SlidersMeal slider = new SlidersMeal();
                    list.Add(slider);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(slider));
                }
                else if (b.Name == "SpicySteakButton")
                {
                    SpicySteakBowl ssb = new SpicySteakBowl();
                    list.Add(ssb);
                    MenuItemClicked?.Invoke(this, new CustomMenuEventArgs(ssb));
                }
            }
        }
    }
}
