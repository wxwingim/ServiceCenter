using DataBase;
using Domain2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class AddFullPurchaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<TypeSparePart> allTypes = DataWorker.GetAllTypeSP();
        public List<TypeSparePart> AllTypes
        {
            get { return allTypes; }
            set
            {
                allTypes = value;
                NotifyPropertyChanged("AllTypes");
            }
        }

        private string nameSparePart;
        private TypeSparePart typeSparePart;
        private int priceSparePart;
        private int amountSparePart;
        private Money money = new Money();

        public string NameSparePart { get { return nameSparePart; } set { nameSparePart = value; } }
        public TypeSparePart TypeSparePart { get { return typeSparePart; } set { typeSparePart = value; } }
        public int PriceSparePart { get { return priceSparePart; } set { priceSparePart = value; } }
        public string price { get { return price; } set { price = value; } }
        public int AmountSparePart { get { return amountSparePart; } set { amountSparePart = value; } }

        public PurchaseModel AddToPurchase()
        {
            var result = new PurchaseModel
            {
                nameSpare = nameSparePart,
                price = priceSparePart,
                priceSP = money.IntMoneyToString(priceSparePart),
                amount = amountSparePart,
                type = typeSparePart
            };
            return result;
        }

        public void AddNewSparePart(List<PurchaseModel> spareParts)
        {
            foreach (PurchaseModel sparePart in spareParts)
            {
                DataWorker.CreatePurchase(sparePart);
            }
        }
    }
}
