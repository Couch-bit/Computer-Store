﻿using System.Collections.ObjectModel;
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

        private void RefreshStore()
        {
            LstSuppliers.ItemsSource = new ObservableCollection
                <Supplier>(store.Suppliers);
            LstCustomers.ItemsSource = new ObservableCollection
                <Customer>(store.Customers);
            LstOrders.ItemsSource = new ObservableCollection
                <Order>(store.GetAllOrders().FindAll(p => p.Status));
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

        private void BtnModifyItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
