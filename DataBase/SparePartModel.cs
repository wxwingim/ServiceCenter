using System;

namespace DataBase
{
    public class SparePartModel
    {


        public int PurchaseId { get; set; }
        public int amount { get; set; }
        public DateTime datePurchase { get; set; }
        public string nameSpare { get; set; }
        public int priceSpare { get; set; }
        public string typeSparePart { get; set; }
    }
}
