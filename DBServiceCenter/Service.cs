using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBServiceCenter
{
    public class Service
    {
        [Key]
        public int key_service { get; set; }

        [Required]
        public string name_service { get; set;}

        [Required]
        public int price_service { get; set; }

        public List<Work_repair> work_repairs { get; set; }
    }
}
