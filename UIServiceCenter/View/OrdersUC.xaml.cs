using DataBase;
using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;


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

        private void leftMouseClick(object sender, RoutedEventArgs e)
        {
            OrderProfileWindow win2 = new OrderProfileWindow((OrderModel)ViewAllOrders.SelectedItem, this);
            win2.Owner = Application.Current.MainWindow;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win2.ShowDialog();
        }

        private void status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatusRepair selectedStatus = (StatusRepair)status.SelectedItem;
            if (selectedStatus.StatusId == -1)
            {
                ViewAllOrders.ItemsSource = DataWorker.GetAllOrders();
            }
            else
            {
                ViewAllOrders.ItemsSource = DataWorker.GetAllOrdersByStatusRepair(selectedStatus.StatusId);
            }
        }
    }
}
