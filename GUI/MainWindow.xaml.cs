using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Forms;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Store store;
        public MainWindow()
        {
            store = new();
            InitializeComponent();
            RefreshStore();
        }


        private void StoreOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new()
            {
                Filter = "Json files (*.json) | *.json"
            };
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string fname = dlg.FileName;
                try
                {
                    store = Store.Deserialize(fname);
                    RefreshStore();
                    
                }
                catch (FileNotFoundException exc)
                {
                    System.Windows.Forms.MessageBox.Show
                        (exc.Message, "Error" ,
                        MessageBoxButtons.OK);
                }
                catch (SerializationException exc)
                {
                    System.Windows.Forms.MessageBox.Show
                        (exc.Message, "Error",
                        MessageBoxButtons.OK);
                }
                catch (JsonException)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Unexpected Error", "Error",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void MenuItemSave_Click(object sender,
            RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                store.Serialize(filename);
            }
        }

        private void MenuItemClose_Click(object sender,
            RoutedEventArgs e)
        {
            Close();
        }


        private void Login_Click(object sender,
            RoutedEventArgs e)
        {
            Customer? customer = store.Customers.Find
                (x => x.Email == TxtLogin.Text);
            if (customer is null)
            {
                System.Windows.Forms.MessageBox.Show
                        ("No Account exists for this Email Address",
                        "Error",
                        MessageBoxButtons.OK);
            }
            else
            {
                if (customer.Password == TxtPassword.Password)
                {
                    StoreClientWindow dlg = new(store, customer);
                    bool? result = dlg.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Incorrect Password",
                        "Error",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void Create_Click(object sender,
            RoutedEventArgs e)
        {
            ClientCreationWindow window = new(store);
            bool? result = window.ShowDialog();
            if (result == true)
            {
                RefreshStore();
            }
        }

        public void RefreshStore()
        {
            TxtName.Text = store.Name;
            TxtSupplier.Text = store.Suppliers.Count.ToString();
            TxtCustomer.Text = store.Customers.Count.ToString();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            StoreManagementWindow window = new(store);
            window.ShowDialog();
            RefreshStore();
        }

        private void TxtName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            store.Name = TxtName.Text;
        }
    }
}