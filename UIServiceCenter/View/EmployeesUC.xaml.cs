using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeesUC.xaml
    /// </summary>
    public partial class EmployeesUC : UserControl
    {
        public static ListView? AllEmployeesView;

        public EmployeesUC()
        {
            InitializeComponent();
        }

        private void CreateNewEmployee(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow win2 = new AddNewEmployeeWindow(this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }

        public void DoStuff()
        {
            ViewAllEmployees.ItemsSource = DataWorker.GetAllEmployees();
        }
    }
}
