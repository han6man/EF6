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

namespace IsraelGeoDataWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //using (IsraelGeoDataDB db = new IsraelGeoDataDB())
            //{
            //    var cities = db.Cities;
            //    foreach (City c in cities)
            //        Console.WriteLine("{0}.{1} - {2}", c.city_code, c.city_name, c.city_name_foreign);
            //}

            InitializeComponent();
        }
    }
}
