using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBServiceCenter
{
    public class Work_order
    {
        [Key]
        public int num_order { get; set; }

        [Required]
        public int duration_quarantee { get; set;}

        [Required, MaxLength(21)]
        public string status_repair { get; set; }

        [Required, DefaultValue("false")]
        public bool status_paymnt { get; set; }

        [Required, DefaultValue("false")]
        public bool status_delivery { get; set; }

        [Key]
        [ForeignKey("Admission_for_repair")]
        public int num_admission { get; set; }

        public Admission_for_repair Admission_for_repair { get; set; }

        public Akt_delivery num_delivery { get; set; }

        public List<Work_repair> work_repairs { get; set; }
    }
}
