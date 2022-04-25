using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Service
    {
        public Service()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quarantee { get; set; }
        public int IdDeviceType { get; set; }

        public virtual DeviceType IdDeviceTypeNavigation { get; set; } = null!;
        public virtual ICollection<Work> Works { get; set; }
    }
}
