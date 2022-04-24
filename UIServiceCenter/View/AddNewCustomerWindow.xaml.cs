using Domain2;
using System;
using System.Windows;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewCustomerWindow.xaml
    /// </summary>
    public partial class AddNewCustomerWindow : Window
    {
        CustomersUC parent;
        AddNewOrderWindow parentOrder;

        public AddNewCustomerWindow(CustomersUC parent)
        {
            InitializeComponent();
            DataContext = new AddCustomerView();
            this.parent = parent;
        }

        public AddNewCustomerWindow(AddNewOrderWindow parent)
        {
            InitializeComponent();
            DataContext = new AddCustomerView();
            this.parentOrder = parent;
        }

        private void BackCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            PersonD customer = new CustomerD(lastName.Text, firstName.Text, middleName.Text, Phone.Text, email.Text);
            try
            {
                if (!customer.CheckInput()) throw new Exception();
                else
                {
                    AddCustomerView addCustomer = new AddCustomerView
                    {
                        LastName = customer.LastName,
                        FirstName = customer.FirstName,
                        MiddleName = customer.MiddleName,
                        Phone = customer.Phone,
                        Email = customer.Email
                    };
                    addCustomer.CreateNewCustomer();

                    if (parent != null)
                    {
                        parent.DoStuff();
                    }

                    if (parentOrder != null)
                    {
                        parentOrder.OrderCustomerName.Content = addCustomer.LastName + " " + addCustomer.FirstName + " " + addCustomer.MiddleName;
                        parentOrder.OrderCustomerPhone.Content = addCustomer.Phone;
                        parentOrder.CustomerBefore.Visibility = Visibility.Hidden;
                        parentOrder.CustomerAfter.Visibility = Visibility.Visible;
                        parentOrder.selectedCustomer.Items.Add(DataWorker.GetCustomerByPhone(customer.Phone));
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                messege.Text = "некорректный ввод";
            }
        }
    }
}
