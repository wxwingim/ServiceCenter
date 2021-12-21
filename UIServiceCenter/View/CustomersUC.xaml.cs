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
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для CustomersUC.xaml
    /// </summary>
    public partial class CustomersUC : UserControl
    {
        public static ListView? AllCustomersView;

        public CustomersUC()
        {
            InitializeComponent();
        }

        private void CreateNewCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomerWindow win2 = new AddNewCustomerWindow(this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }

        public void DoStuff()
        {
            ViewAllCustomers.ItemsSource = DataWorker.GetAllCustomers();
        }
    }
}
