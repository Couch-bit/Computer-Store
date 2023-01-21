using System.Collections.ObjectModel;
using System.Windows;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ViewOrderWindow.xaml
    /// </summary>
    public partial class ViewOrderWindow : Window
    {
        private readonly Store store;
        private readonly Order order;
        private readonly Customer customer;

        public ViewOrderWindow(Store store, Order order)
        {
            this.store = store;
            this.order = order;
            InitializeComponent();
            customer = store.GetCustomer(order);
            TxtCustomer.Text = customer.ToString();
            TxtOrder.Text = order.CalculateOrderCost().ToString();
            TxtDelivery.Text = order.CalculateShippingCost
                ().ToString();
            TxtCost.Text = order.CalculateTotalCost().ToString();
            TxtCountry.Text = customer.Country;
            TxtCity.Text = customer.City;
            TxtStreet.Text = customer.Street;
            TxtZipCode.Text = customer.ZipCode;
            LstItems.ItemsSource = new
                ObservableCollection<CartItem>(order.Cart);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            customer.RemoveOrder(order);
            DialogResult = true;
        }

        private void BtnRealize_Click(object sender, RoutedEventArgs e)
        {
            order.Status = true;
            DialogResult = true;
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}