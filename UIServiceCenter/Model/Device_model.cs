using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Device_model
    {
        [Key]
        public int keyModel { get; set; }

        [Required]
        [MaxLength(100)]
        public string nameModel { get; set; }

        public Device_type typeId { get; set; }

        public List<Customer_device> devices { get; set; }
    }
}
