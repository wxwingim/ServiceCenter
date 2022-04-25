using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Consumption
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdPurchase { get; set; }
        public int Amount { get; set; }

        public virtual Order IdOrderNavigation { get; set; } = null!;
        public virtual Purchase IdPurchaseNavigation { get; set; } = null!;
    }
}
