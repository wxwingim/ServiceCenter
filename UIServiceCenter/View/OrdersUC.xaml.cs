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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;


namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class OrdersUC : UserControl
    {
        public OrdersUC()
        {
            InitializeComponent();
        }

        private void CreateNewOrder(object sender, RoutedEventArgs e)
        {
            AddNewOrderWindow win2 = new AddNewOrderWindow(this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }

        public void DoStuff()
        {
            ViewAllOrders.ItemsSource = DataWorker.GetAllOrders();
        }
    }
}
