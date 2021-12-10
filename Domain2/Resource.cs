using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2
{
    public class Resource
    {
        public Resource CreateResource(string type, string name, int price)
        {
            Resource resource = null;
            if (type == "Service")
                resource = new Service(name, price);

            else if (type == "SparePart")
            {
                // проверка + лог расхода

                resource = new SparePart(name, price);
            }
                

            return resource;
        }

        public virtual string DisplayResource() { return null; }
    }
}
