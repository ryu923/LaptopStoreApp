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
using System.Globalization;

namespace Week05_DataBinding_Assignment3
{
    /// <summary>
    /// Interaction logic for DataBindingDetails.xaml
    /// </summary>
    public partial class DataBindingDetails : Window
    {
        static Random random = new Random();

        ObservableCollection<Laptop> laptops = Laptop.GetAllLaptops();

        public DataBindingDetails()
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
            List<Includes> include;
            string handle;

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

            public List<Includes> Include
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

            public string Handle
            {
                get
                {
                    return handle;
                }
                set
                {
                    if (handle != value)
                    {
                        handle = value;
                        Notify("Handle");
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

                // Creating array of pictures
                string[] handles = "apple asus acer hp lenovo dell".Split();

                Laptop laps = new Laptop
                {
                    Brand = brand,
                    ModelNo = random.Next(1000, 9999),
                    IsSsd = random.NextDouble() < 0.4,
                    SerialNo = random.Next(10000000, 99999999),
                    Color = color[random.Next(color.Length)],
                    Include = new List<Includes>(),
                    Handle = "Images\\" + handles[random.Next(handles.Length)] + ".png"
                };

                int numberOfInclude = random.Next(2, 4);

                for (int i = 0; i < numberOfInclude; i++)
                {

                }

                Includes.AddInclude(laps, random.Next(Includes.NUMBER_OF_INCLUDE), random.Next(2, 4));

                return laps;
            }

            public class Includes
            {
                public static int NUMBER_OF_INCLUDE { get { return includeItems.Length; } }

                static string[] includeItems = "WirelessMouse BluetoothEarPhone BluetoothSpeaker LaptopBag ACPowerAdaptor".Split();
                static string[] includeItemsBrands = "HP Logiteck Remixed LG Samsung".Split();

                public string IncludeItems { get; set; }
                public string IncludeItemsBrands { get; set; }

                public static void AddInclude(Laptop lap, int startPosition, int numberOfIncludeItems)
                {
                    for (int i = 0; i < numberOfIncludeItems; i++)
                    {
                        int position = (startPosition + i) % includeItems.Length;

                        lap.Include.Add(new Includes() { IncludeItemsBrands = includeItemsBrands[position], IncludeItems = includeItems[position] });
                    }
                }
            }
        }
    }

    [ValueConversion(typeof(bool), typeof(string))]
    public class BoolToSSDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSsd = (bool)value;

            return isSsd ? "SSD" : "HDD";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value.ToString().ToLower() == "ssd") ? "true" : "false";
        }
    }
}
