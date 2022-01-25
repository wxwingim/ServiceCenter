using DataBase;

namespace Domain2
{
    public class ConsumptionD : ResourceD
    {
        int amount;
        SparePart sparePart;
        Consumption consumption;

        public Consumption Consumption { get { return consumption; } }
        public SparePart SparePart { get { return sparePart; } }
        public int Amount { get { return amount; } }

        public ConsumptionD(SparePart sparePart, int amount, Consumption consumption)
        {
            this.consumption = consumption;
            this.sparePart = sparePart;
            this.amount = amount;
        }

        // склад

        public int Price()
        {
            return sparePart.priceSpare * amount;
        }
    }
}
