using Classes;
using System;
using System.Windows;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientCreationWindow : Window
    {
        private readonly Store store;

        public ClientCreationWindow(Store store)
        {
            this.store = store;
            InitializeComponent();
            CmbType.Text = "Private Customer";
            TxtName.IsEnabled = false;
            TxtNip.IsEnabled = false;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (!TxtPassword.Password.Equals(TxtConfirm.Password))
            {
                System.Windows.Forms.MessageBox.Show
                    ("Passwords Do Not Match", "Warning", MessageBoxButtons.OK);
            }
            else if (TxtNip.IsEnabled)
            {
                try
                { 
                    Company company = new(TxtName.Text, TxtNip.Text,
                        TxtCountry.Text, TxtCity.Text, TxtStreet.Text,
                        TxtZipCode.Text, TxtPhone.Text, TxtEmail.Text,
                        TxtPassword.Password);
                    store.AddCustomer(company);
                    DialogResult = true;
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show
                    (exc.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                try
                {
                    PrivateCustomer privateCustomer = 
                        new(TxtFirstName.Text, TxtLastName.Text,
                        TxtCountry.Text, TxtCity.Text,
                        TxtStreet.Text, TxtZipCode.Text,
                        TxtPhone.Text, TxtEmail.Text,
                        TxtPassword.Password);
                    store.AddCustomer(privateCustomer);
                    DialogResult = true;
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show
                    (exc.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbType_DropDownClosed(object sender,
            EventArgs e)
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