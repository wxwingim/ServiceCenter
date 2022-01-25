using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class AdmissionForRepair
    {
        [Key]
        public int num_admission { get; set; }

        //[Required]
        public DateTime? date_limit { get; set; }

        [Required]
        public bool quarantee { get; set; }

        [Required]
        public DateTime date_admission { get; set; }

        [ForeignKey("customerDevice")]
        public int idCustDev { get; set; }

        public CustomerDevice customerDevice { get; set; }

        public List<WorkOrder> work_Order { get; set; }
    }
}
