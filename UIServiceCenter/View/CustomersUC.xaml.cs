using DataBase;
using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;

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

        private void leftMouseClick(object sender, RoutedEventArgs e)
        {
            CustomerProfileWindow win2 = new CustomerProfileWindow((Customer)ViewAllCustomers.SelectedItem, this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }
    }
}
