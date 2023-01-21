using System.Collections.ObjectModel;
using System.Windows;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for StoreManagementWindow.xaml
    /// </summary>
    public partial class StoreManagementWindow : Window
    {
        private readonly Store store;
        public StoreManagementWindow(Store store)
        {
            this.store = store;
            InitializeComponent();
            RefreshStore();
        }

        private void AddSupplier_Click(object sender,
            RoutedEventArgs e)
        {
            SupplierWindow window = new(store);
            bool? result = window.ShowDialog();
            if (result == true)
            {
                RefreshStore();
            }
        }

        private void ModifySupplier_Click(object sender,
            RoutedEventArgs e)
        {
            if (LstSuppliers.SelectedItem is Supplier supplier)
            {
                SupplierWindow window = new(store, supplier);
                bool? result = window.ShowDialog();
                if (result == true)
                {
                    RefreshStore();
                }
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnModifyItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshStore()
        {
            LstProducts.ItemsSource = new ObservableCollection
                <Product>(store.GetAllProducts());
            LstSuppliers.ItemsSource = new ObservableCollection
                <Supplier>(store.Suppliers);
            LstCustomers.ItemsSource = new ObservableCollection
                <Customer>(store.Customers);
            LstOrders.ItemsSource = new ObservableCollection
                <Order>(store.GetAllOrders().FindAll(p => !p.Status));
        }
    }
}