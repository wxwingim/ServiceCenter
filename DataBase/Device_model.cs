using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Device_model
    {
        [Key]
        public int keyModel { get; set; }

        [Required]
        [MaxLength(100)]
        public string nameModel { get; set; }

        [ForeignKey("deviceType")]
        public int typeId { get; set; }

        public Device_type deviceType { get; set; }

        public List<Customer_device> devices { get; set; }
    }
}
