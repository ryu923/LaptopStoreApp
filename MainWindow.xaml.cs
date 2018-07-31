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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week05_DataBinding_Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonHandler_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;

            switch(fe.Name)
            {
                case "btnLaptopInfo":
                    new DataBinding().Show();
                    break;

                case "btnLoadCollection":
                    new DataBindingLoadCollection().Show();
                    break;

                case "btnDataGrid":
                    new DataBindingDataGrid().Show();
                    break;

                case "btnDetails":
                    new DataBindingDetails().Show();
                    break;
            }
        }
    }
}
