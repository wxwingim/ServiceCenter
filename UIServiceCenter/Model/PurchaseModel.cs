using DataBase;
using Domain2;

namespace UIServiceCenter.Model
{
    public class PurchaseModel
    {
        private Money money = new Money();
        public string nameSpare { get; set; }
        public int price { get; set; }
        public string priceSP { get; set; }
        public int amount { get; set; }
        public TypeSparePart type { get; set; }
        public PurchaseModel()
        {
            //priceSP = money.IntMoneyToString(price);
        }
    }
}
