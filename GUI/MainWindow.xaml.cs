using System.IO;
using System.Windows;
using System.Windows.Forms;
using Classes;
using Microsoft.Win32;

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
        }

        // TODO
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
                }
                catch (FileNotFoundException)
                {

                }
                catch (SerializationException)
                {
                    return;
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        // TODO
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ClientCreationWindow okno = new();
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                
            }
        }
    }
}
