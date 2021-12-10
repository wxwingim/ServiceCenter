using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2
{
    public class WorkItem
    {
        Resource resource;
        int amount;

        public Resource Resource { get { return resource; } }

        public WorkItem(Resource resource, int amount)
        {
            this.resource = resource;
            this.amount = amount;
        }

        public void CreateItem(string type, string name, int price)
        {
            resource = resource.CreateResource(type, name, price);
        }

        public string DisplayItemWork()
        {
            return resource.DisplayResource() + " " + amount;
        }
    }
}
