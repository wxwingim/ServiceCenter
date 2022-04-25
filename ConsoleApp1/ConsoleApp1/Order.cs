using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Order
    {
        public Order()
        {
            Consumptions = new HashSet<Consumption>();
            Visits = new HashSet<Visit>();
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public int IdStatus { get; set; }

        public virtual StatusesRepair IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<Consumption> Consumptions { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
