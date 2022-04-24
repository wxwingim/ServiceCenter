using System.Windows;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        OrderProfileWindow parent;
        public DeliveryWindow(OrderProfileWindow parent)
        {
            InitializeComponent();
            this.parent = parent;

            akt.Text += parent.number.Text;
            ViewAllServices.ItemsSource = parent.ViewAllServices.Items;
            ViewAllSpareParts.ItemsSource = parent.ViewAllSpareParts.Items;
            price.Text = parent.price.Text;
            guarantee.Text = parent.guarantee.Text;
            guarant.Text = parent.guarant.Text;
        }
    }
}
