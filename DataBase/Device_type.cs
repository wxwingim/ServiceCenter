using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Device_type
    {
        [Key]
        public int typeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string nameType { get; set; }

        public List<Device_model> devices { get; set; }
    }
}
