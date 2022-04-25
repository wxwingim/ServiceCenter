using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Purchase
    {
        public Purchase()
        {
            Consumptions = new HashSet<Consumption>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int Quarantee { get; set; }
        public int IdPartType { get; set; }
        public int? Amount { get; set; }
        public DateOnly? DatePurchase { get; set; }

        public virtual PartType IdPartTypeNavigation { get; set; } = null!;
        public virtual ICollection<Consumption> Consumptions { get; set; }
    }
}
