using DataBase;
using Domain2;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для OrderProfileWindow.xaml
    /// </summary>
    public partial class OrderProfileWindow : Window
    {
        CustomerProfileWindow parentCustom;
        OrdersUC parent;
        OrderModel order;
        OrderD orderD;

        public OrderProfileWindow(OrderModel order, OrdersUC parent)
        {
            InitializeComponent();
            DataContext = new OrderProfileViewModel();
            this.order = order;
            this.parent = parent;

            List<ResourceD> resources = DataWorker.GetResourceDByNumOrder(order.numOrder);
            ViewAllServices.ItemsSource = DataWorker.GetWorkRepairModelsByNumOrder(order.numOrder);
            ViewAllSpareParts.ItemsSource = DataWorker.GetStorageModelsByNumOrder(order.numOrder);
            number.Text += order.numOrder.ToString();

            OrderProfileViewModel orderProfile = new OrderProfileViewModel(order);

            orderD = new OrderD(resources, DataWorker.GetAllPurchase(), orderProfile.StatusRepair.StatusName, order.statusPaymnt);
            if (order.quarantee)
            {
                guarantee.Text = "Ремонт по гарантии";
            }
            price.Text = orderD.SummOrder();
            guarant.Text = orderD.GuaranteeOrder().ToString();

            if (orderD.CheckStatuses())
            {
                Pay.Visibility = Visibility.Collapsed;
                Paid.Visibility = Visibility.Visible;
            }
            else
            {
                Paid.Visibility = Visibility.Collapsed;
                Pay.Visibility = Visibility.Visible;
            }

            CustomerPhone.Content = orderProfile.CustomerPhone;
            CustomerName.Content = orderProfile.CustomerName;
            type.SelectedValue = orderProfile.TypeDevice.typeId;
            model.Text = orderProfile.Model;
            defect.Text = orderProfile.Defect;
            equipment.Text = orderProfile.Equipment;
            mechanicalDamage.Text = orderProfile.MechanicalDamage;
            status.SelectedValue = orderProfile.StatusRepair.StatusId;

        }

        public OrderProfileWindow(CustomerProfileWindow parentCustom, OrderModel order)
        {
            InitializeComponent();
            DataContext = new OrderProfileViewModel();
            this.order = order;
            this.parentCustom = parentCustom;

            List<ResourceD> resources = DataWorker.GetResourceDByNumOrder(order.numOrder);
            ViewAllServices.ItemsSource = DataWorker.GetWorkRepairModelsByNumOrder(order.numOrder);
            ViewAllSpareParts.ItemsSource = DataWorker.GetStorageModelsByNumOrder(order.numOrder);

            orderD = new OrderD(resources, DataWorker.GetAllPurchase());

            if (order.quarantee)
            {
                guarantee.Text = "Ремонт по гарантии";
            }
            price.Text = orderD.SummOrder();

            OrderProfileViewModel orderProfile = new OrderProfileViewModel(order);

            if (orderD.CheckStatuses())
            {
                Pay.Visibility = Visibility.Collapsed;
                massegePay.Visibility = Visibility.Collapsed;
                Paid.Visibility = Visibility.Visible;
            }
            else
            {
                Paid.Visibility = Visibility.Collapsed;
                Pay.Visibility = Visibility.Visible;
                massegePay.Visibility = Visibility.Visible;
            }

            CustomerPhone.Content = orderProfile.CustomerPhone;
            CustomerName.Content = orderProfile.CustomerName;
            type.SelectedValue = orderProfile.TypeDevice.typeId;
            model.Text = orderProfile.Model;
            defect.Text = orderProfile.Defect;
            equipment.Text = orderProfile.Equipment;
            mechanicalDamage.Text = orderProfile.MechanicalDamage;
            status.SelectedValue = orderProfile.StatusRepair.StatusId;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Paid.Visibility == Visibility.Visible)
            {
                order.statusPaymnt = true;
            }

            OrderProfileViewModel orderProfile = new OrderProfileViewModel(order);

            orderProfile.TypeDevice = (DeviceType)type.SelectedItem;
            orderProfile.Model = model.Text;
            orderProfile.Defect = defect.Text;
            orderProfile.Equipment = equipment.Text;
            orderProfile.MechanicalDamage = mechanicalDamage.Text;
            orderProfile.StatusRepair = (StatusRepair)status.SelectedItem;

            orderProfile.EditOrder();

            List<ServiceD> listWorkRep = orderD.Services();
            List<ConsumptionD> listConsump = orderD.Consumptions();

            foreach (ServiceD service in listWorkRep)
            {
                if (service.WorkRepair.numOrder == 0)
                {
                    DataWorker.CreateWorkRepair(order.numOrder, service.Service.keyService, service.Employee.idWork);
                }
            }

            foreach (ConsumptionD consumption in listConsump)
            {
                if (consumption.Consumption.numOrder == 0)
                {
                    DataWorker.CreateConsumption(consumption.Amount, consumption.SparePart.idSpare, order.numOrder);
                }
            }


            if (parent != null)
            {
                parent.DoStuff();
            }
            if (parentCustom != null)
            {
                parentCustom.DoStuff();
            }
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddResource win = new AddResource(this, orderD);

            win.Owner = Application.Current.MainWindow;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((StatusRepair)status.SelectedItem).StatusName != "Готов") throw new Exception();

                Pay.Visibility = Visibility.Collapsed;
                Paid.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                massegePay.Text = "Статус заказа некорректен";
            }
        }

        private void status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            massegePay.Text = "";
            if (Paid.Visibility == Visibility.Visible && ((StatusRepair)status.SelectedItem).StatusName != "Готов" && ((StatusRepair)status.SelectedItem).StatusName != "Выдан" && !order.statusPaymnt)
            {
                Pay.Visibility = Visibility.Visible;
                Paid.Visibility = Visibility.Collapsed;
            }

            try
            {
                if ((Paid.Visibility == Visibility.Visible && ((StatusRepair)status.SelectedItem).StatusName != "Готов" && ((StatusRepair)status.SelectedItem).StatusName != "Выдан" && order.statusPaymnt))
                {
                    status.SelectedValue = DataWorker.GetStatusRepair(order.statusRepair).StatusId;
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                massegePay.Text = "Заказ уже оплачен";
            }

        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            DeliveryWindow win = new DeliveryWindow(this);

            win.Owner = Application.Current.MainWindow;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }
    }
}
