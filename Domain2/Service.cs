using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2
{
    internal class Service: Resource
    {
        string name;
        int price;

        public Service()
        {

        }
        public Service(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public override string DisplayResource()
        {
            return "Услуга " + name + " ( " + price + " )";
        }
    }
}
