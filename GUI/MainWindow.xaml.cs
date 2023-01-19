using System.IO;
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

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                store.Serialize(filename);
            }
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // TODO
        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        // TODO
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ClientCreationWindow okno = new(store.Customers);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                
            }
        }

        public void RefreshStore()
        {
            TxtName.Text = store.Name;
            TxtSupplier.Text = store.Suppliers.Count.ToString();
            TxtCustomer.Text = store.Customers.Count.ToString();
        }
    }
}
