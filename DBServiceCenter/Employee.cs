using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DBServiceCenter
{
    public class Employee
    {
        [Key]
        public int id_work { get; set; }

        [Required]
        [MaxLength(20)]
        public string last_work { get; set; }

        [Required]
        [MaxLength(20)]
        public string first_work { get; set; }

        [MaxLength(20)]
        public string? middle_work { get; set; }

        [MaxLength(255)]
        public string mail_work { get; set; }

        [Required]
        [MaxLength(11)]
        public string tel_work { get; set; }

        [Required]
        [MaxLength(50)]
        public string position { get; set; }

        public List<Work_repair> work_repairs { get; set; }
    }
}
