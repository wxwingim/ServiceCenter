using DataBase;
using Domain2;
using System;
using System.Windows;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для CustomerProfileWindow.xaml
    /// </summary>
    public partial class CustomerProfileWindow : Window
    {
        CustomersUC parent;
        Customer customer;

        public CustomerProfileWindow(Customer customer, CustomersUC parent)
        {
            InitializeComponent();
            DataContext = new CustomerProfileViewModel();
            this.parent = parent;
            this.customer = customer;

            lastName.Text = customer.lastCustom;
            firstName.Text = customer.firstCustom;
            middleName.Text = customer.middleCustom;
            phone.Text = customer.telCustom;
            email.Text = customer.mailCustom;

            ViewAllOrders.ItemsSource = DataWorker.GetAllOrdersByIdCustomer(customer.idCustom);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CustomerProfileViewModel customerProfileViewModel = new CustomerProfileViewModel();
            customerProfileViewModel.OldCustomer = customer;

            CustomerD cust = new CustomerD(lastName.Text, firstName.Text, middleName.Text, phone.Text, email.Text);

            try
            {
                if (!cust.CheckInput()) throw new Exception();
                else
                {
                    customerProfileViewModel.NewCustomer = new Customer
                    {
                        lastCustom = cust.LastName,
                        firstCustom = cust.FirstName,
                        middleCustom = cust.MiddleName,
                        telCustom = cust.Phone,
                        mailCustom = cust.Email
                    };
                    customerProfileViewModel.EditCustomer();

                    parent.DoStuff();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                message.Text = "некорректный ввод";
            }
        }

        private void leftMouseClick(object sender, RoutedEventArgs e)
        {
            OrderProfileWindow win = new OrderProfileWindow(this, (OrderModel)ViewAllOrders.SelectedItem);
            win.Owner = Application.Current.MainWindow;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

        public void DoStuff()
        {
            ViewAllOrders.ItemsSource = DataWorker.GetAllOrdersByIdCustomer(customer.idCustom);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
