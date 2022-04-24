using DataBase;
using Domain2;
using System;

namespace UIServiceCenter.Model
{
    public class StorageModel
    {
        public StorageModel(Purchase purchase)
        {
            PurchaseId = purchase.PurchaseId;
            amount = purchase.amount;
            datePurchase = purchase.datePurchase;
            nameSpare = DataWorker.GetSparePartById(purchase.idSpare).nameSpare;
            priceSpare = DataWorker.GetSparePartById(purchase.idSpare).priceSpare;
            price = money.IntMoneyToString(priceSpare);
            typeSparePart = DataWorker.GetTypeSparePartById(DataWorker.GetSparePartById(purchase.idSpare).IdTypeSP).name;
            IdSpare = purchase.idSpare;
        }

        public StorageModel(Consumption consumption)
        {
            IdSpare = consumption.idSpare;
            amount = consumption.amount;
            nameSpare = DataWorker.GetSparePartById(consumption.idSpare).nameSpare;
            priceSpare = DataWorker.GetSparePartById(consumption.idSpare).priceSpare;
            price = money.IntMoneyToString(priceSpare);
            typeSparePart = DataWorker.GetTypeSparePartById(DataWorker.GetSparePartById(consumption.idSpare).IdTypeSP).name;
        }
        private Money money = new Money();

        public int IdSpare { get; set; }
        public int PurchaseId { get; set; }
        public int amount { get; set; }
        public DateTime datePurchase { get; set; }
        public string nameSpare { get; set; }
        public int priceSpare { get; set; }
        public string price { get; set; }
        public string typeSparePart { get; set; }
    }
}
