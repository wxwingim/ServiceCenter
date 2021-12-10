using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Work_repair
    {
        [Key]
        public int num_work { get; set; }

        public DateTime? date_ready { get; set; }

        [Key]
        public Work_order num_order { get; set; }

        public Service key_service { get; set; }

        public Employee id_work { get; set; }
    }
}
