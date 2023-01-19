using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            products = new();
            InitializeComponent();
            LstProducts.ItemsSource = supplier.Products;
            TxtName.Text = supplier.Name;
            TxtNIP.Text = supplier.Nip;
            TxtCountry.Text = supplier.Country;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                products.ForEach(p => result.AddProduct(p));
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
            }
        }
    }
}
