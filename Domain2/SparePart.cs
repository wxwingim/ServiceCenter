using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2
{
    public class SparePart: Resource
    {
        string name;
        int price;

        public int Price { get { return price; } }
        public string Name { get { return name; } }

        public SparePart()
        {

        }

        public SparePart(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public override string DisplayResource()
        {
            return "Запчасть " + name + " ( " + price + " )";
        }
    }
}
