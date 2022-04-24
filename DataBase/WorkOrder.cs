using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class WorkOrder
    {
        // Key
        [Key]
        public int numOrder { get; set; }

        [Required]
        [DefaultValue("false")]
        public bool statusPaymnt { get; set; }

        [Required]
        [DefaultValue("false")]
        public bool statusDelivery { get; set; }

        [ForeignKey("AdmissionForRepair")]
        public int num_admission { get; set; }
        public AdmissionForRepair AdmissionForRepair { get; set; }

        [ForeignKey("statusRepair")]
        public int StatusId { get; set; }
        public StatusRepair statusRepair { get; set; }

        public DateTime? dateDelivery { get; set; }

        public List<WorkRepair> workRepairs { get; set; }

        public List<Consumption> consumptions { get; set; }
    }
}
