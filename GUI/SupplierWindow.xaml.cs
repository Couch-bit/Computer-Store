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
        private Store store;
        private List<Product> products;
        public SupplierWindow(Store store)
        {
            this.store = store;
            products = new();
            InitializeComponent();
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
                Supplier supplier = new(TxtName.Text, TxtNIP.Text,
                    TxtCountry.Text);
                products.ForEach(p => supplier.AddProduct(p));
                store.AddSupplier(supplier);
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
