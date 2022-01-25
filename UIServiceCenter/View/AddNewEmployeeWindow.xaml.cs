using Domain2;
using System;
using System.Windows;
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

            PersonD employee = new EmployeeD(lastName.Text, firstName.Text, middleName.Text, phone.Text, email.Text, position.Text);

            try
            {
                if (!employee.CheckInput()) throw new Exception();
                else
                {
                    AddEmployeeView addEmployee = new AddEmployeeView
                    {
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        MiddleName = employee.MiddleName,
                        Phone = employee.Phone,
                        Email = employee.Email,
                        Position = position.Text
                    };
                    addEmployee.CreateNewEmployee();
                    parent.DoStuff();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                messege.Text = "некорректный ввод";
            }
        }

        private void BackEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
