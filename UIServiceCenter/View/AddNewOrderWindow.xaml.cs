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
    /// Логика взаимодействия для AddNewOrderWindow.xaml
    /// </summary>
    public partial class AddNewOrderWindow : Window
    {
        OrdersUC parent;

        public AddNewOrderWindow(OrdersUC parent)
        {
            InitializeComponent();
            CustomerAfter.Visibility = Visibility.Hidden;
            DataContext = new AddOrderView();
            this.parent = parent;
        }

        private void ChooseCustomer_Click(object sender, RoutedEventArgs e)
        {
            ChooseClientWindow win2 = new ChooseClientWindow(this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            // ...
            parent.DoStuff();
            this.Close();
        }


        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            // ...
            parent.DoStuff();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
