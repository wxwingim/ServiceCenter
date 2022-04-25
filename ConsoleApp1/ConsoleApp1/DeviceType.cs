using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            OrderRequests = new HashSet<OrderRequest>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string NameType { get; set; } = null!;

        public virtual ICollection<OrderRequest> OrderRequests { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
