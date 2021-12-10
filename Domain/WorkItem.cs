using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkItem
    {
        private int amount;
        private Resource resource;

        public WorkItem(int amount, Resource resource)
        {
            this.amount = amount;
            this.resource = resource;
        }
    }
}
