using DataBase;
using Domain2;
using System;
using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AddResource.xaml
    /// </summary>
    public partial class AddResource : Window
    {
        OrderProfileWindow parent;
        OrderD orderD;

        public AddResource(OrderProfileWindow parent, OrderD orderD)
        {
            InitializeComponent();
            DataContext = new AddResourceViewModel();

            this.parent = parent;
            this.orderD = orderD;

            ViewSparePart.ItemsSource = DataWorker.GetStorage(orderD.ActualPurchase);

            ServiceChoose.Visibility = Visibility.Hidden;
            SparePartChoose.Visibility = Visibility.Hidden;
            amountEnter.Visibility = Visibility.Hidden;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (ViewAllServices.IsVisible)
            {
                Employee employee = (Employee)employeeChoose.SelectedItem;
                Service service = (Service)ViewAllServices.SelectedItem;
                // Domain//
                ResourceD resource = new ServiceD(service, employee, new WorkRepair { idWork = employee.idWork, keyService = service.keyService });
                orderD.Resources.Add(resource);
                //      //

                parent.ViewAllServices.ItemsSource = DataWorker.ServiceToWorkRepairModel(orderD.Services());

                parent.price.Text = orderD.SummOrder();
                parent.guarant.Text = orderD.GuaranteeOrder().ToString();
                this.Close();
            }
            if (ViewSparePart.IsVisible)
            {
                StorageModel sm = (StorageModel)ViewSparePart.SelectedItem;

                try
                {
                    int res;
                    bool isInt = Int32.TryParse(amount.Text, out res);
                    if (!isInt)
                    {
                        throw new Exception();
                    }

                    ResourceD resource = new ConsumptionD(DataWorker.GetSparePartById(sm.IdSpare), int.Parse(amount.Text), new Consumption { idSpare = sm.IdSpare, amount = int.Parse(amount.Text) });
                    if (!orderD.CheckResource((ConsumptionD)resource))
                    {
                        messege.Text = "неверное количество";
                    }
                    else
                    {
                        orderD.AddConsumption((ConsumptionD)resource);

                        parent.ViewAllSpareParts.ItemsSource = DataWorker.ConsumptionToStoragModel(orderD.Consumptions());

                        parent.price.Text = orderD.SummOrder();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    messege.Text = "некорректный ввод";
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SparePart_Checked(object sender, RoutedEventArgs e)
        {
            ServiceChoose.Visibility = Visibility.Hidden;
            SparePartChoose.Visibility = Visibility.Visible;
            amountEnter.Visibility = Visibility.Visible;
        }

        private void Service_Checked(object sender, RoutedEventArgs e)
        {
            SparePartChoose.Visibility = Visibility.Hidden;
            ServiceChoose.Visibility = Visibility.Visible;
            amountEnter.Visibility = Visibility.Hidden;
        }

        private void types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeSparePart type = (TypeSparePart)types.SelectedValue;
            ViewSparePart.ItemsSource = null;
            ViewSparePart.ItemsSource = DataWorker.GetStorage(type);
        }
    }
}
