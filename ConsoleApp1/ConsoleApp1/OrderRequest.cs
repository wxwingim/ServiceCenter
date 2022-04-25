using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class OrderRequest
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdDeviceType { get; set; }
        public string Model { get; set; } = null!;
        public string Defect { get; set; } = null!;
        public string? Equipment { get; set; }
        public string? MachanicalDamage { get; set; }
        public string? Addres { get; set; }
        public bool Quarantee { get; set; }
        public DateOnly DateLimit { get; set; }
        public DateTime DateRequest { get; set; }

        public virtual User IdCustomerNavigation { get; set; } = null!;
        public virtual DeviceType IdDeviceTypeNavigation { get; set; } = null!;
    }
}
