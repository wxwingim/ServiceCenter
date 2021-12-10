using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Device_model
    {
        [Key]
        public int key_model { get; set; }

        [Required]
        [MaxLength(100)]
        public string name_model { get; set; }

        public Device_type type_id { get; set; }

        public List<Customer_device> devices { get; set; }
    }
}
