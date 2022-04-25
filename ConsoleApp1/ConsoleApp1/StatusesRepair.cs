using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class StatusesRepair
    {
        public StatusesRepair()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string NameStatus { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
