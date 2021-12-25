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
using DataBase;

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
            DataContext = new ChooseClientView();
            this.parent = parent;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            //customer = ViewAllCustomers.SelectedItem as Customer;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
