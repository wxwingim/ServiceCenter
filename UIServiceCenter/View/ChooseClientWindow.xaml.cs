using DataBase;
using System.Windows;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для ChooseClientWindow.xaml
    /// </summary>
    public partial class ChooseClientWindow : Window
    {
        AddNewOrderWindow parent;

        public ChooseClientWindow(AddNewOrderWindow parent)
        {
            InitializeComponent();
            DataContext = new ChooseClientViewModel();
            this.parent = parent;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();

            customer = (Customer)ViewAllCustomers.SelectedItem;
            parent.CustomerBefore.Visibility = Visibility.Hidden;
            parent.CustomerAfter.Visibility = Visibility.Visible;
            parent.OrderCustomerName.Content = customer.lastCustom + " " + customer.firstCustom + " " + customer.middleCustom;
            parent.OrderCustomerPhone.Content = customer.telCustom;
            parent.selectedCustomer.Items.Add(customer);

            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
