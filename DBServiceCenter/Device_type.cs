using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DBServiceCenter
{
    public class Device_type
    {
        [Key]
        public int type_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name_type { get; set; }

        public List<Device_model> devices { get; set; }
    }
}
