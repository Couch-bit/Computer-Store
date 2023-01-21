using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
            items = product.Items.ToList();
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDate.SelectedDate is not null &&
                !string.IsNullOrEmpty(TxtNumber.Text))
            {
                items.Add(new Item(TxtNumber.Text,
                    (System.DateTime)TxtDate.SelectedDate));
                RefreshStore();
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (LstItems.SelectedItem is Item item)
            {
                product.RemoveItem(item);
                RefreshStore();
            }
        }

        private void RefreshStore()
        {
            LstItems.ItemsSource = new
                ObservableCollection<Item>(items);
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            product.Items.Clear();
            items.ForEach(product.Items.Add);
            DialogResult = true;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}