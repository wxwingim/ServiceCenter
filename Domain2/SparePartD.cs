using DataBase;

namespace Domain2
{
    public class SparePartD
    {
        string name;
        int price;

        public int Price { get; set; }
        public string Name { get; set; }

        public SparePartD(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public SparePartD(SparePart sparePart)
        {
            price = sparePart.priceSpare;
            name = sparePart.nameSpare;
        }
    }
}
