using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientCreationWindow : Window
    {
        private List<Customer> customers;
        public ClientCreationWindow(List<Customer> customers)
        {
            this.customers = customers;
            InitializeComponent();
            CmbType.Text = "Private Customer";
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNip.IsEnabled)
            {
                
            }
            else
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbType_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            if (CmbType.Text.Equals("Company"))
            {
                TxtFirstName.IsEnabled = false;
                TxtLastName.IsEnabled = false;
                TxtName.IsEnabled = true;
                TxtNip.IsEnabled = true;
            }
            else if (CmbType.Text.Equals("Private Customer"))
            {
                TxtName.IsEnabled = false;
                TxtNip.IsEnabled = false;
                TxtFirstName.IsEnabled = true;
                TxtLastName.IsEnabled = true;
            }
        }
    }
}
