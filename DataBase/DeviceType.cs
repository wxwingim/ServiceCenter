using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class DeviceType
    {
        [Key]
        public int typeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string nameType { get; set; }

        public List<CustomerDevice> customer_Devices { get; set; }

        //public List<Device_model> devices { get; set; }
    }
}
