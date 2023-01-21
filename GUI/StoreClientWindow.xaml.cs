using System.Windows;
using System.Windows.Controls;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class StoreClientWindow : Window
    {
        private Store store;
        private Customer customer;

        public StoreClientWindow(Store store, Customer customer)
        {
            InitializeComponent();
            this.store = store;
            this.customer = customer;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
