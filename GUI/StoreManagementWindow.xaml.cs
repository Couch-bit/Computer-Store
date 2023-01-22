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

        private void BtnAddSupplier_Click(object sender,
            RoutedEventArgs e)
        {
            SupplierWindow window = new(store);
            bool? result = window.ShowDialog();
            if (result == true)
            {
                RefreshStore();
            }
        }

        private void BtnModifySupplier_Click(object sender,
            RoutedEventArgs e)
        {
            if (LstSuppliers.SelectedItem is Supplier supplier)
            {
                SupplierWindow window = new(store, supplier);
                window.ShowDialog();
                RefreshStore();
            }
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnViewOrder_Click(object sender,
            RoutedEventArgs e)
        {
            if (LstOrders.SelectedItem is Order order)
            {
                ViewOrderWindow dlg = new(store, order);
                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    RefreshStore();
                }
            }
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
                <Order>();
            LstOrders.ItemsSource = new ObservableCollection
                <Order>(store.GetAllOrders().FindAll(p => !p.Status));
        }
    }
}