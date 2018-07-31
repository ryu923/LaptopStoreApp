using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Add [using System.ComponentModel;] for [INotifyPropertyChanged] interface
using System.ComponentModel;

namespace Week05_DataBinding_Assignment3
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        Laptop laps = Laptop.GetOneLaptop();

        public DataBinding()
        {
            InitializeComponent();

            cboColor.ItemsSource = new List<string> { "White", "Black", "Silver" };

            DataContext = laps;
        }

        public class Laptop : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            // Instance Variable
            string brand;
            double modelNo;
            bool isSsd;
            int serialNo;
            string color;
            List<string> include;

            // Public Properties
            #region Properties
            public string Brand
            {
                get
                {
                    return brand;
                }
                set
                {
                    if(brand != value)
                    {
                        brand = value;
                        Notify("Brand");
                    }
                }
            }

            public double ModelNo
            {
                get
                {
                    return modelNo;
                }
                set
                {
                    if (modelNo != value)
                    {
                        modelNo = value;
                        Notify("ModelNo");
                    }
                }
            }

            public bool IsSsd
            {
                get
                {
                    return isSsd;
                }
                set
                {
                    if (isSsd != value)
                    {
                        isSsd = value;
                        Notify("IsSsd");
                    }
                }
            }

            public int SerialNo
            {
                get
                {
                    return serialNo;
                }
                set
                {
                    if (serialNo != value)
                    {
                        serialNo = value;
                        Notify("SerialNo");
                    }
                }
            }

            public string Color
            {
                get
                {
                    return color;
                }
                set
                {
                    if (color != value)
                    {
                        color = value;
                        Notify("Color");
                    }
                }
            }

            

            public List<string> Include
            {
                get
                {
                    return include;
                }
                set
                {
                    if (include != value)
                    {
                        include = value;
                        Notify("Include");
                    }
                }
            }

            #endregion

            protected void Notify(string propBrand)
            {
                if(this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propBrand));
                }
            }

            public static Laptop GetOneLaptop()
            {
                return new Laptop()
                {
                    Brand = "MacBook Pro 13",
                    ModelNo = 1001,
                    IsSsd = true,
                    SerialNo = 93821053,
                    Color = "White",
                    Include = new List<string>() { "Wireless Mouse", "Bluetooth EarPhone", "Laptop Bag", "AC Power Adaptor" }
                };
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            laps.Brand = "Asus ZenBook 14";
            laps.ModelNo = 2001;
            laps.IsSsd = true;
            laps.SerialNo = 736152303;
            laps.Color = "Silver";
            laps.Include = new List<string>() { "Wireless Mouse", "Bluetooth Speaker", "Laptop Bag", "AC Power Adaptor" };
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            string result;

            result = $"Brand: {laps.Brand} \nModel No: {laps.ModelNo} ";
            result += (laps.IsSsd) ? "[SSD]" : "[HDD]";
            result += "\nSerial No: " + laps.SerialNo;
            result += "\nColor: " + laps.Color;

            string include = string.Join(", ", laps.Include);
            result += "\nInclude: " + include;

            MessageBox.Show(result, "Laptop Information", MessageBoxButton.OK);
        }
    }
}
