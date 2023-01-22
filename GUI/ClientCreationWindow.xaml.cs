using System;
using System.Windows;
using System.Windows.Forms;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientCreationWindow : Window
    {
        private readonly Store store;
        private readonly Customer? customer;

        public ClientCreationWindow(Store store)
        {
            this.store = store;
            InitializeComponent();
            CmbType.Text = "PrivateCustomer";
            RefreshStore();
        }

        public ClientCreationWindow(Store store, Customer customer)
        {
            this.store = store;
            this.customer = customer;
            InitializeComponent();
            CmbType.Text = customer.GetType().Name;
            RefreshStore();
            InitiateWindow();
            CmbType.IsEnabled = false;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!TxtPassword.Password.Equals(TxtConfirm.Password))
            {
                System.Windows.Forms.MessageBox.Show
                    ("Passwords Do Not Match", "Warning",
                    MessageBoxButtons.OK);
            }
            if (TxtNip.IsEnabled)
            {
                ParseCompany();
            }
            else
            {
                ParsePrivate(); 
            }
        }

        private void ParseCompany()
        {
            try
            {
                Company company = new(TxtName.Text, TxtNip.Text,
                    TxtCountry.Text, TxtCity.Text, TxtStreet.Text,
                    TxtZipCode.Text, TxtPhone.Text, TxtEmail.Text,
                    TxtPassword.Password);
                if (customer is not null)
                {
                    customer.Orders.ForEach(company.AddOrder);
                    store.RemoveCustomer(customer);
                    try
                    {
                        store.AddCustomer(company);
                    }
                    catch 
                    {
                        store.AddCustomer(customer);
                        throw;
                    }
                }
                else
                {
                    store.AddCustomer(company);
                }
                DialogResult = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
                --Customer.CurrentId;
            }
        }

        private void ParsePrivate()
        {
            try
            {
                PrivateCustomer privateCustomer =
                    new(TxtFirstName.Text, TxtLastName.Text,
                    TxtCountry.Text, TxtCity.Text,
                    TxtStreet.Text, TxtZipCode.Text,
                    TxtPhone.Text, TxtEmail.Text,
                    TxtPassword.Password);
                if (customer is not null)
                {
                    customer.Orders.ForEach(privateCustomer.AddOrder);
                    store.RemoveCustomer(customer);
                    try
                    {
                        store.AddCustomer(privateCustomer);
                    }
                    catch
                    {
                        store.AddCustomer(customer);
                        throw;
                    }
                }
                else
                {
                    store.AddCustomer(privateCustomer);
                }
                
                DialogResult = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
                --Customer.CurrentId;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbType_DropDownClosed(object sender,
            EventArgs e)
        {
            RefreshStore();
        }

        private void InitiateWindow()
        {
            if (customer is null)
            {
                return;
            }
            TxtCountry.Text = customer.Country; 
            TxtCity.Text = customer.City;
            TxtStreet.Text = customer.Street;
            TxtZipCode.Text = customer.ZipCode;
            TxtPhone.Text = customer.PhoneNumber;
            TxtEmail.Text = customer.Email;
            TxtPassword.Password = customer.Password;
            TxtConfirm.Password = customer.Password;
            if (CmbType.Text.Equals("Company"))
            {
                InitiateCompany();
            }
            else if (CmbType.Text.Equals("PrivateCustomer"))
            {
                InitiatePrivate();
            }
        }

        private void InitiateCompany()
        {
            if (customer is Company company)
            {
                TxtName.Text = company.Name;
                TxtNip.Text = company.Nip;
            }
        }

        private void InitiatePrivate() 
        {
            if (customer is PrivateCustomer privateCustomer)
            {
                TxtFirstName.Text = privateCustomer.FirstName;
                TxtLastName.Text= privateCustomer.LastName;
            }
        }

        private void RefreshStore()
        {
            if (CmbType.Text.Equals("Company"))
            {
                TxtFirstName.IsEnabled = false;
                TxtLastName.IsEnabled = false;
                TxtName.IsEnabled = true;
                TxtNip.IsEnabled = true;
            }
            else if (CmbType.Text.Equals("PrivateCustomer"))
            {
                TxtName.IsEnabled = false;
                TxtNip.IsEnabled = false;
                TxtFirstName.IsEnabled = true;
                TxtLastName.IsEnabled = true;
            }
        }
    }
}