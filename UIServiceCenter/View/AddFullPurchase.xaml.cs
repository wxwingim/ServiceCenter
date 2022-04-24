using DataBase;
using Domain2;
using System.Collections.Generic;
using System.Windows;
using UIServiceCenter.Model;
using UIServiceCenter.ViewModel;

namespace UIServiceCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AddFullPurchase.xaml
    /// </summary>
    public partial class AddFullPurchase : Window
    {
        StorageUC parent;
        List<PurchaseModel> spareParts = new List<PurchaseModel>();

        public AddFullPurchase(StorageUC parent)
        {
            InitializeComponent();
            DataContext = new AddFullPurchaseViewModel();
            this.parent = parent;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Money money = new Money();
            AddFullPurchaseViewModel addFullPurchaseViewModel = new AddFullPurchaseViewModel();

            addFullPurchaseViewModel.TypeSparePart = (TypeSparePart)types.SelectedValue;
            addFullPurchaseViewModel.NameSparePart = nameSparePart.Text;
            addFullPurchaseViewModel.PriceSparePart = money.StringMoneyToInt(priceSparePart.Text);
            addFullPurchaseViewModel.AmountSparePart = int.Parse(amountSparePart.Text);

            spareParts.Add(addFullPurchaseViewModel.AddToPurchase());

            ViewAllSpareParts.ItemsSource = null;
            ViewAllSpareParts.ItemsSource = spareParts;

            nameSparePart.Clear();
            priceSparePart.Clear();
            types.SelectedIndex = -1;
            amountSparePart.Clear();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddFullPurchaseViewModel add = new AddFullPurchaseViewModel();
            add.AddNewSparePart(spareParts);

            parent.DoStuff();
            this.Close();
        }
    }
}
