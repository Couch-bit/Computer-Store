using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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
        private Order order;

        public StoreClientWindow(Store store, Customer customer)
        {
            InitializeComponent();
            this.store = store;
            this.customer = customer;
            order = new();
            RefreshStore();
        }

        private void LstProducts_SelectionChanged
            (object sender, SelectionChangedEventArgs e)
        {
            if (LstProducts.SelectedItem is Product product)
            {
                TxtDescription.Text =
                product.Description;
            }
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (LstProducts.SelectedItem is Product product)
            {
                try
                {
                    int amount = int.Parse(TxtAmount.Text);
                    order.Add(product, amount);
                    RefreshStore();
                }
                catch (FormatException)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Invalid amount", "Error",
                        MessageBoxButtons.OK);
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show
                        (exc.Message, "Error",
                        MessageBoxButtons.OK);
                }
            }
            
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LstOrder.SelectedItem is Product product)
            {
                order.Delete(product);
                RefreshStore();
            }
        }

        private void RefreshStore()
        {
            List<Product> allProducts = store.GetAllProducts();
            allProducts.Sort();
            LstProducts.ItemsSource = new
                ObservableCollection<Product>(allProducts);
            LstOrder.ItemsSource = new
                ObservableCollection<Product>(order.Cart.Keys);
            TxtOrder.Text = $"{order.CalculateOrderCost():c2}";
            TxtDelivery.Text = $"{order.CalculateShippingCost():c2}";
            TxtCost.Text = $"{order.CalculateTotalCost():c2}";
        }

        private void LstOrder_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            if (LstOrder.SelectedItem is Product product)
            {
                TxtAmountOrder.Text =
                order.Cart[product].ToString() ?? "";
            }
        }
    }
}