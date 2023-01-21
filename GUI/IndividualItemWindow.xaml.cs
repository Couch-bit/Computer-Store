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
    /// Interaction logic for IndividualItemWindow.xaml
    /// </summary>
    public partial class IndividualItemWindow : Window
    {
        private readonly Product product;
        private readonly List<Item> items;

        public IndividualItemWindow(Product product)
        {
            this.product = product;
            items = new(product.Items);
            InitializeComponent();
            RefreshStore();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDate.SelectedDate is not null &&
                !string.IsNullOrEmpty(TxtNumber.Text))
            {
                items.Add(new Item(TxtNumber.Text,
                    (DateTime)TxtDate.SelectedDate));
                RefreshStore();
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (LstItems.SelectedItem is Item item)
            {
                items.Remove(item);
                RefreshStore();
            }
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hardware hardware = new();
                --Product.CurrentId;
                items.ForEach(hardware.AddItem);
                product.Items.Clear();
                items.ForEach(product.AddItem);
                DialogResult = true;
            }
            catch (Exception exc) 
            {
                System.Windows.Forms.MessageBox.Show
                        (exc.Message,
                        "Error",
                        MessageBoxButtons.OK);
            }
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshStore()
        {
            LstItems.ItemsSource = new
                ObservableCollection<Item>(items);
        }
    }
}