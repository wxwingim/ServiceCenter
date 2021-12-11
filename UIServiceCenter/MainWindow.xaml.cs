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
using MaterialDesignThemes.Wpf;
using UIServiceCenter.ViewModel;
using UIServiceCenter.View;

namespace UIServiceCenter
{

    public interface IMainWindowsCodeBehind
    {
        /// <summary>
        /// Показ сообщения для пользователя
        /// </summary>
        /// <param name="message">текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        /// Загрузка нужной View
        /// </summary>
        /// <param name="view">экземпляр UserControl</param>
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Customers,
        Orders,
        Employees,
        Storage,
        Jobs
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            DataContext = new DataManageVM();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MenuViewModel vm = new MenuViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;

            //загрузка стартовой View
            LoadView(ViewType.Customers);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {

                case ViewType.Orders:
                    OrdersUC viewO = new OrdersUC();
                    OrdersViewModel vmO = new OrdersViewModel(this);
                    viewO.DataContext = vmO;
                    this.OutputView.Content = viewO;
                    break;

                case ViewType.Customers:
                    CustomersUC viewC = new CustomersUC();
                    CustomersViewModel vmC = new CustomersViewModel(this);
                    viewC.DataContext = vmC;
                    this.OutputView.Content = viewC;
                    break;

                case ViewType.Employees:
                    EmployeesUC viewE = new EmployeesUC();
                    EmployeesViewModel vmE = new EmployeesViewModel(this);
                    viewE.DataContext = vmE;
                    this.OutputView.Content = viewE;
                    break;

                case ViewType.Storage:
                    StorageUC viewS = new StorageUC();
                    StorageViewModel vmS = new StorageViewModel(this);
                    viewS.DataContext = vmS;
                    this.OutputView.Content = viewS;
                    break;

                case ViewType.Jobs:
                    JobsUC viewJ = new JobsUC();
                    JobsViewModel vmJ = new JobsViewModel(this);
                    viewJ.DataContext = vmJ;
                    this.OutputView.Content = viewJ;
                    break;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }

}
