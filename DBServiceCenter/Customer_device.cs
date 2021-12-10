using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Customer_device
    {
        [Key]
        public int id_cust_dev { get; set; }

        [Required]
        public string defect { get; set; }

        public string? equipment { get; set; }

        public string? mechanical_damage { get; set; }

        public Customer id_custom { get; set; }

        public Device_model key_model { get; set; }

        public List<Admission_for_repair> admission_For_Repairs { get; set; }
    }
}
