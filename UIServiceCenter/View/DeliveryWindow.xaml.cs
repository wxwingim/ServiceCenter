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
        }
    }
}
