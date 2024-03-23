using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BuildYourBowl.Data;

namespace PointOfSale
{
    public class CustomMenuEventArgs : RoutedEventArgs
    {
        public IMenuItem MenuItem { get; private set; }

        public CustomMenuEventArgs(IMenuItem menuItem)
        {
            MenuItem = menuItem;
        }
    }
}
