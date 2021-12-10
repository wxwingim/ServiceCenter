using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Resource
    {
        string type, name;

        int price;

        public Resource(string type, string name, int price)
        {
            this.type = type;
            this.name = name;
            this.price = price;
        }

        public Resource Choise()
        {
            if (type == "Service") return new Service(type, name, price);
            if (type == "SparePart") return new SparePart(type, name, price);
            return null;
        }

        public virtual string DisplayResource() 
        { 
            return Choise().DisplayResource();
        }
    }
}
