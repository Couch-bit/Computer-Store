using System.Collections.ObjectModel;
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

        public IndividualItemWindow(Product product)
        {
            this.product = product;
            InitializeComponent();
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDate.SelectedDate is not null &&
                !string.IsNullOrEmpty(TxtNumber.Text))
            {
                product.AddItem(new Item(TxtNumber.Text,
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
                ObservableCollection<Item>(product.Items);
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
