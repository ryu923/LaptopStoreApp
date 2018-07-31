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

// Add
using System.Collections.ObjectModel; // For [ObservableCollection]
using System.ComponentModel; // For [INotifyPropertyChanged]

namespace Week05_DataBinding_Assignment3
{
    /// <summary>
    /// Interaction logic for DataBindingLoadCollection.xaml
    /// </summary>
    public partial class DataBindingLoadCollection : Window
    {
        static Random random = new Random();

        ObservableCollection<Laptop> laptops = Laptop.GetAllLaptops();

        public DataBindingLoadCollection()
        {
            InitializeComponent();

            DataContext = laptops;
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
                    if (brand != value)
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
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propBrand));
                }
            }

            public static ObservableCollection<Laptop> GetAllLaptops()
            {
                ObservableCollection<Laptop> laps = new ObservableCollection<Laptop>();
                laps.Add(CreateLaptop("MacBook Pro 13"));
                laps.Add(CreateLaptop("MacBook Air 13.3"));
                laps.Add(CreateLaptop("MacBook Pro 13.3"));
                laps.Add(CreateLaptop("MacBook Air 13"));
                laps.Add(CreateLaptop("Asus VivoBook 15.6"));
                laps.Add(CreateLaptop("Asus ZenBook 14"));
                laps.Add(CreateLaptop("Asus X555QA 15.6"));
                laps.Add(CreateLaptop("Asus ZenBook Flip 14"));
                laps.Add(CreateLaptop("Acer Aspire5 15.6"));
                laps.Add(CreateLaptop("Acer Swift3 14"));
                laps.Add(CreateLaptop("Acer Switch3 12.2"));
                laps.Add(CreateLaptop("Acer CromeBook 11.6"));
                laps.Add(CreateLaptop("HP Stream 14"));
                laps.Add(CreateLaptop("HP ProBook 14"));
                laps.Add(CreateLaptop("HP Pavillion X360 11.6"));
                laps.Add(CreateLaptop("HP Envy x360 15.6"));
                laps.Add(CreateLaptop("Lenovo IdeaPad 320 15.6"));
                laps.Add(CreateLaptop("Lenovo X131E 11.6"));
                laps.Add(CreateLaptop("Lenovo Thinkpad T440 14"));
                laps.Add(CreateLaptop("Lenovo CromeBook Thinkpad 11E 11.6"));
                laps.Add(CreateLaptop("Dell Inspiron 15.6"));
                laps.Add(CreateLaptop("Dell Gaming 15.6"));
                laps.Add(CreateLaptop("Dell Latitude E6430 3rd Gen 14"));
                laps.Add(CreateLaptop("Dell Alienware 15.6"));

                return laps;
            }
            
            private static Laptop CreateLaptop(string brand)
            {

                // Creating array of Color
                string[] color = "White Black Silver".Split();

                // Creating array of Include
                string[] include = "WirelessMouse BluetoothEarPhone BluetoothSpeaker LaptopBag ACPowerAdaptor".Split();

                return new Laptop
                {
                    Brand = brand,
                    ModelNo = random.Next(1000, 9999),
                    IsSsd = random.NextDouble() < 0.4,
                    SerialNo = random.Next(10000000,99999999),
                    Color = color[random.Next(color.Length)],
                    Include = new List<string>
                    {
                        include[random.Next(include.Length)],
                        include[random.Next(include.Length)],
                        include[random.Next(include.Length)]
                    }
                };
            }
        }
    }
}
