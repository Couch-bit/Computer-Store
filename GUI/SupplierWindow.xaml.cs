using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        private readonly Store store;
        private readonly Supplier? supplier;
        private readonly List<Product> products;

        public SupplierWindow(Store store)
        {
            this.store = store;
            products = new();
            InitializeComponent();
        }

        public SupplierWindow(Store store, Supplier supplier)
        {
            this.store = store;
            this.supplier = supplier;
            products = supplier.Products.ToList();
            InitializeComponent();
            TxtName.Text = supplier.Name;
            TxtNIP.Text = supplier.Nip;
            TxtCountry.Text = supplier.Country;
            RefreshStore();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Supplier result = new(TxtName.Text, TxtNIP.Text,
                    TxtCountry.Text);
                products.ForEach(result.AddProduct);
                if (supplier is not null)
                {
                    store.RemoveSupplier(supplier);
                }
                store.AddSupplier(result);
                DialogResult = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                        (exc.Message, "Error",
                        MessageBoxButtons.OK);
                --Supplier.CurrentId;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow dlg = new(products);
            dlg.ShowDialog();
            RefreshStore();
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            if (LstProducts.SelectedItem is Product product)
            {
                ProductWindow dlg = new(products, product);
                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    RefreshStore();
                }
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (LstProducts.SelectedItem is Product product)
            {
                products.Remove(product);
                RefreshStore();
            }
        }

        private void RefreshStore()
        {
            LstProducts.ItemsSource = new
                ObservableCollection<Product>(products);
        }
    }
}