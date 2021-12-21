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
    /// Логика взаимодействия для AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        EmployeesUC parent;

        public AddNewEmployeeWindow(EmployeesUC parent)
        {
            InitializeComponent();
            DataContext = new AddEmployeeView();
            this.parent = parent;
        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeView addEmployeeView = new AddEmployeeView();
            addEmployeeView.LastName = this.lastName.Text;
            addEmployeeView.FirstName = this.firstName.Text;
            addEmployeeView.MiddleName = this.middleName.Text;
            addEmployeeView.Phone = this.phone.Text;
            addEmployeeView.Email = this.email.Text;
            addEmployeeView.Position = this.position.Text;
            addEmployeeView.CreateNewEmployee();
            parent.DoStuff();
            this.Close();
        }

        private void BackEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
