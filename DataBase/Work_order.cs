using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Work_order
    {
        // Key
        [Key]
        public int numOrder { get; set; }

        [Required]
        public int durationQuarantee { get; set; }

        [Required, MaxLength(21), DefaultValue("Принят в ремонт")]
        public string statusRepair { get; set; }

        [Required, DefaultValue("false")]
        public bool statusPaymnt { get; set; }

        [Required, DefaultValue("false")]
        public bool statusDelivery { get; set; }

        // Key
        [ForeignKey("AdmissionForRepair")]
        public int num_admission { get; set; }

        public Admission_for_repair AdmissionForRepair { get; set; }

        [ForeignKey("aktDelivery")]
        public int numDeliveri { get; set; }

        public Akt_delivery aktDelivery { get; set; }

        public List<Work_repair> workRepairs { get; set; }
    }
}
