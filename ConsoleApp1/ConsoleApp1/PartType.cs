using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class PartType
    {
        public PartType()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string NameType { get; set; } = null!;

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
