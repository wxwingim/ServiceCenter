using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain2
{
    public class Supply
    {
        SparePart sparePart;
        int amount;

        public Supply(SparePart sparePart, int amount)
        {
            this.sparePart = sparePart;
            this.amount = amount;
        }

        public int Sum()
        {
            return amount * sparePart.Price;
        }
    }
}
