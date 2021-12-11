using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIServiceCenter.Model
{
    public class Work_order
    {
        
        public int numOrder { get; set; }

        [Required]
        public int durationQuarantee { get; set; }

        [Required, MaxLength(21)]
        public string statusRepair { get; set; }

        [Required, DefaultValue("false")]
        public bool statusPaymnt { get; set; }

        [Required, DefaultValue("false")]
        public bool statusDelivery { get; set; }

        
        [ForeignKey("Admission_for_repair")]
        public int numAdmission { get; set; }

        public Admission_for_repair AdmissionForRepair { get; set; }

        public Akt_delivery numDelivery { get; set; }

        public List<Work_repair> workRepairs { get; set; }
    }
}
