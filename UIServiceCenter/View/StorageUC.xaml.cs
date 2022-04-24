using DataBase;
using System.Windows;
using System.Windows.Controls;
using UIServiceCenter.Model;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для StorageUC.xaml
    /// </summary>
    public partial class StorageUC : UserControl
    {
        public StorageUC()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddFullPurchase newWin = new AddFullPurchase(this);
            newWin.Owner = Application.Current.MainWindow;
            newWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWin.ShowDialog();
        }

        public void DoStuff()
        {
            ViewAllSpareParts.ItemsSource = DataWorker.GetStorage();
        }

        private void types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeSparePart SelectedType = (TypeSparePart)types.SelectedItem;
            if (SelectedType.IdTypeSP == -1)
            {
                ViewAllSpareParts.ItemsSource = DataWorker.GetStorage();
            }
            else
            {
                ViewAllSpareParts.ItemsSource = DataWorker.GetStorage(SelectedType);
            }
        }
    }
}
