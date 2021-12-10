using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Customer
    {
        [Key]
        public int id_custom { get; set; }

        [Required]
        [MaxLength(20)]
        public string last_custom { get; set;}

        [Required]
        [MaxLength(20)]
        public string first_custom { get; set; }

        [MaxLength(20)]
        public string? middle_custom { get; set; }

        [MaxLength(255)]
        public string? mail_custom { get; set;}

        [Required]
        [MaxLength(11)]
        public string tel_custom { get; set; }
        
        public List<Customer_device> devices { get; set; }
    }
}
