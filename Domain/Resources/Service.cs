using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Service: Resource
    {
        private string name { get; }

        private int price { get; }

        public Service(string type, string name, int price) : base(type, name, price)
        {
            this.name = name;
            this.price = price;
        }

        public override string DisplayResource()
        {
            return "Использована услуга " + name;
        }
    }
}
