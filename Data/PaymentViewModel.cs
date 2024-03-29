using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for when properties change
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// if the user has paid enough
        /// </summary>
        public string PaidEnoughString 
        {
            get 
            {
                if (PaidEnough) return "";
                else return "Insufficient Amount";
            }
        }
        /// <summary>
        /// Whether or not the user is paying more than the total
        /// </summary>
        public bool PaidEnough { get; set; } = true;

        /// <summary>
        /// The order passed to this class
        /// </summary>
        public Order _order { get; init; }

        /// <summary>
        /// The subtotal of the order
        /// </summary>
        public decimal SubTotal => _order.Subtotal;

        /// <summary>
        /// The tax of the order
        /// </summary>
        public decimal Tax => _order.Tax;


        /// <summary>
        /// The total of the order
        /// </summary>
        public decimal Total => _order.Total;

        private decimal _paid;
        /// <summary>
        /// How much the user is paying
        /// </summary>
        public decimal Paid 
        {
            get => _paid;
            set 
            {
                _paid = Convert.ToDecimal(value);
                if (_paid < Total)
                {
                    PaidEnough = false;
                    _paid = Total;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaidEnough)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaidEnoughString)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                    throw new ArgumentException("You must at least pay the total");
                }
                else 
                {
                    PaidEnough = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaidEnough)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaidEnoughString)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                }
            }
        }

        /// <summary>
        /// Prints the receipt of the order
        /// </summary>
        public string Receipt 
        {
            get 
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Order: {_order.Number}");
                sb.AppendLine($"Date: {_order.PlacedAt}");
                sb.AppendLine();

                foreach (IMenuItem item in _order) 
                {
                    sb.AppendLine($"{item.Name}    ${item.Price}");
                    foreach (string prepInfo in item.PreparationInformation) 
                    {
                        sb.AppendLine($"    {prepInfo}");
                    }
                    sb.AppendLine();
                }

                sb.AppendLine();
                sb.AppendLine($"SubTotal: {SubTotal:C}");
                sb.AppendLine($"Tax: {Tax:C}");
                sb.AppendLine($"Total: {Total:C}");
                sb.AppendLine();
                sb.AppendLine($"Paid: {Paid:C}");
                sb.AppendLine($"Change: {Change:C}");
                sb.AppendLine("--------------------------------");

                return sb.ToString();
            }
        }

        /// <summary>
        /// The change that is owed
        /// </summary>
        public decimal Change 
        {
            get 
            {
                return Paid - Total;
            }
        }

        /// <summary>
        /// Constructs the payment view model
        /// </summary>
        /// <param name="order">the order to be used</param>
        public PaymentViewModel(Order order) 
        {
            _order = order;
            _paid = _order.Total;
        }
    }
}
