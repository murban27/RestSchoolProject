using DesktopRestaurant.Client;
using DesktopRestaurant.Controller;
using DesktopRestaurant.OBJECTS;
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

namespace DesktopRestaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tables tables = new Tables();
        ApiCall apiCall = new ApiCall();
        GetMethod getMethod = new GetMethod();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            InicializaceClient.Heslo = "Tesco123";
            InicializaceClient.UserName = "murban27";

            var call = apiCall.GetMethodAsync(tables, getMethod.GetTables);
                call.Wait();
           


                MessageBox.Show("OOU");
            
           





        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
