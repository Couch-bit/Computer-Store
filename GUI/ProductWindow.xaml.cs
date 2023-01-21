using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Classes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly List<Product> products;
        private readonly Product? product;

        public ProductWindow(List<Product> products)
        {
            this.products = products;
            InitializeComponent();
            BtnAddItem.IsEnabled = false;
            CmbType.Text = "Hardware";
            UpdateWindow();
        }

        public ProductWindow(List<Product> products, Product product)
        {
            this.products = products;
            this.product = product;
            InitializeComponent();
            InitiateWindow();
            UpdateWindow();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CmbType.Text.Equals("Hardware"))
            {
                AddHardware();
            }
            else if (CmbType.Text.Equals("Software"))
            {
                AddSoftware();
            }
            else if (CmbType.Text.Equals("Accessory"))
            {
                AddAccessory();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddHardware()
        {
            try
            {
                HardwareType type = CmbHardware.Text
                    switch
                {
                    "GPU" => HardwareType.GPU,
                    "CPU" => HardwareType.CPU,
                    "RAM" => HardwareType.RAM,
                    "Motherboard" => HardwareType.Motherboard,
                    "Power Supply" => HardwareType.PowerSupply,
                    "Drive" => HardwareType.Drive,
                    _ => HardwareType.Other
                };
                if (double.TryParse
                    (TxtWeight.Text, out double weight) &&
                    double.TryParse
                    (TxtLength.Text, out double length) &&
                    double.TryParse
                    (TxtHeight.Text, out double height) &&
                    double.TryParse
                    (TxtWidth.Text, out double width) &&
                    decimal.TryParse
                    (TxtDiscount.Text, out decimal discount) &&
                    decimal.TryParse
                    (TxtPrice.Text, out decimal price) &&
                    decimal.TryParse
                    (TxtVAT.Text, out decimal vat))
                {
                    Hardware hardware = new(weight,
                                    length, height,
                                    width, type, TxtName.Text,
                                    TxtDescription.Text,
                                    discount,
                                    price, vat);
                    if (product is not null)
                    {
                        products.Remove(product);
                    }
                    products.Add(hardware);
                    DialogResult = true;
                }
                else
                {
                    throw new ArgumentException
                        ("Make Sure all the necessary" +
                        " fields are numeric");
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void AddSoftware()
        {
            try
            {
                Architecture architecture = CmbArchitecture.Text
                    switch
                {
                    "Bit32" => Architecture.Bit32,
                    _ => Architecture.Bit64,
                };
                if (TimeSpan.TryParse
                    (TxtLicense.Text, out TimeSpan license) &&
                    decimal.TryParse
                    (TxtDiscount.Text, out decimal discount) &&
                    decimal.TryParse
                    (TxtPrice.Text, out decimal price) &&
                    decimal.TryParse
                    (TxtVAT.Text, out decimal vat))
                {
                    Software software = new(TxtVersion.Text,
                        license, architecture,
                        TxtName.Text, TxtDescription.Text,
                        discount, price, vat);
                    if (product is not null)
                    {
                        products.Remove(product);
                    }
                    products.Add(software);
                    DialogResult = true;
                }
                else
                {
                    throw new ArgumentException
                        ("Make Sure all the necessary" +
                        " fields are numeric");
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void AddAccessory()
        {
            try
            {
                AccessoryType type = CmbAccessory.Text switch
                {
                    "Headphones" => AccessoryType.Headphones,
                    "Microphone" => AccessoryType.Microphone,
                    "Mouse" => AccessoryType.Mouse,
                    "Keyboard" => AccessoryType.Keyboard,
                    "Screen" => AccessoryType.Screen,
                    "Cable" => AccessoryType.Cable,
                    _ => AccessoryType.Other
                };
                if (double.TryParse
                    (TxtWeight.Text, out double weight) &&
                    decimal.TryParse
                    (TxtDiscount.Text, out decimal discount) &&
                    decimal.TryParse
                    (TxtPrice.Text, out decimal price) &&
                    decimal.TryParse
                    (TxtVAT.Text, out decimal vat))
                {
                    Accessory accessory = new(weight, type,
                        TxtName.Text, TxtDescription.Text,
                        discount, price, vat);
                    if (product is not null)
                    {
                        products.Remove(product);
                    }
                    products.Add(accessory);
                    DialogResult = true;
                }
                else
                {
                    throw new ArgumentException
                        ("Make Sure all the necessary" +
                        " fields are numeric");
                }
            }
            catch (ArgumentException exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show
                (exc.Message, "Error", MessageBoxButtons.OK);
                --Product.CurrentId;
            }
        }

        private void CmbType_DropDownClosed(object sender,
            EventArgs e)
        {
            UpdateWindow();
        }

        private void InitiateWindow()
        {
            if (product is null)
            {
                return;
            }

            TxtName.Text = product.Name;
            TxtDescription.Text = product.Description;
            TxtDiscount.Text = product.Discount.ToString();
            TxtPrice.Text = product.Price.ToString();
            TxtVAT.Text = product.Vat.ToString();
            CmbType.Text = product.GetType().Name;

            if (CmbType.Text.Equals("Hardware")) 
            {
                InitiateHardware();
            }
            else if (CmbType.Text.Equals("Software")) 
            {
                InitiateSoftware();
            }
            else if (CmbType.Text.Equals("Accessory"))
            {
                InitiateAccessory();
            }
            
        }

        private void InitiateHardware()
        {
            if (product is Hardware hardware)
            {
                TxtWeight.Text = hardware.Weight.ToString();
                TxtHeight.Text = hardware.Height.ToString();
                TxtWidth.Text = hardware.Width.ToString();
                TxtLength.Text = hardware.Length.ToString();
                CmbHardware.Text = hardware.Type.ToString();
            }
        }

        private void InitiateSoftware()
        {
            if (product is Software software)
            {
                TxtVersion.Text = software.Version;
                TxtLicense.Text = software.License.
                    TotalDays.ToString();
                CmbArchitecture.Text = software.
                    TargetArchitecture.ToString();
            }
        }

        private void InitiateAccessory()
        {
            if (product is Accessory accessory)
            {
                TxtWeight.Text = accessory.Weight.ToString();
                CmbAccessory.Text = accessory.Type.ToString();
            }
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (product is not null)
            {
                IndividualItemWindow dlg = new(product);
                dlg.ShowDialog();
            }
        }

        private void UpdateWindow()
        {
            if (CmbType.Text.Equals("Hardware"))
            {
                UpdateHardware();
            }
            else if (CmbType.Text.Equals("Software"))
            {
                UpdateSoftware();
            }
            else if (CmbType.Text.Equals("Accessory"))
            {
                UpdateAccessory();
            }
        }

        private void UpdateHardware()
        {
            TxtWeight.IsEnabled = true;
            TxtHeight.IsEnabled = true;
            TxtWidth.IsEnabled = true;
            TxtLength.IsEnabled = true;
            CmbHardware.IsEnabled = true;
            TxtVersion.IsEnabled = false;
            TxtLicense.IsEnabled = false;
            CmbArchitecture.IsEnabled = false;
            CmbAccessory.IsEnabled = false;
        }

        private void UpdateSoftware()
        {
            TxtVersion.IsEnabled = true;
            TxtLicense.IsEnabled = true;
            CmbArchitecture.IsEnabled = true;
            TxtWeight.IsEnabled = false;
            TxtHeight.IsEnabled = false;
            TxtWidth.IsEnabled = false;
            TxtLength.IsEnabled = false;
            CmbHardware.IsEnabled = false;
            CmbAccessory.IsEnabled = false;
        }

        private void UpdateAccessory()
        {
            TxtWeight.IsEnabled = true;
            CmbAccessory.IsEnabled = true;
            TxtHeight.IsEnabled = false;
            TxtWidth.IsEnabled = false;
            TxtLength.IsEnabled = false;
            CmbHardware.IsEnabled = false;
            TxtVersion.IsEnabled = false;
            TxtLicense.IsEnabled = false;
            CmbArchitecture.IsEnabled = false;
        }
    }
}