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
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewCustomerWindow.xaml
    /// </summary>
    public partial class AddNewCustomerWindow : Window
    {
        CustomersUC parent;

        public AddNewCustomerWindow(CustomersUC parent)
        {
            InitializeComponent();
            DataContext = new AddCustomerView();
            this.parent = parent;
        }

        private void BackCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerView addCustomerView = new AddCustomerView();
            addCustomerView.LastName = this.lastName.Text;
            addCustomerView.FirstName = this.firstName.Text;
            addCustomerView.MiddleName = this.middleName.Text;
            addCustomerView.Phone = this.Phone.Text;
            addCustomerView.Email = this.email.Text;
            addCustomerView.CreateNewCustomer();
            parent.DoStuff();
            this.Close();
        }
    }
}
