using DataBase;
using Domain2;
using System;
using System.Windows;
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
            DataContext = new AddOrderViewModel();
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
            AddNewCustomerWindow addNewCustomerWindow = new AddNewCustomerWindow(this);
            addNewCustomerWindow.Owner = Application.Current.MainWindow;
            addNewCustomerWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addNewCustomerWindow.ShowDialog();
        }

        private void CancelCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerAfter.Visibility = Visibility.Hidden;
            CustomerBefore.Visibility = Visibility.Visible;
        }


        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Customer cm = (Customer)selectedCustomer.Items[0];
            PersonD customer = new CustomerD(cm.lastCustom, cm.firstCustom, cm.middleCustom, cm.telCustom, cm.mailCustom);
            DeviceD deviceCustom = new DeviceD(model.Text, defect.Text, equipment.Text, mechanicalDamage.Text, type.Text, customer);
            try
            {
                if (!deviceCustom.CheckInput()) throw new Exception();
                AdmissionD admissionD = new AdmissionD(deviceCustom, customer, dateLimit.SelectedDate.Value, (bool)quaranteeY.IsChecked ? true : false);
                try
                {
                    AddOrderViewModel addOrder = new AddOrderViewModel(admissionD);

                    addOrder.CreateNewOrder();
                    parent.DoStuff();
                    this.Close();
                }
                catch (Exception ex)
                {
                    message.Text = "некорректный ввод";
                }
            }
            catch (Exception ex)
            {
                message.Text = "Данные устройства введены неверно";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
