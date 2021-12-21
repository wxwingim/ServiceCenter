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
    public class Admission_for_repair
    {
        [Key]
        public int num_admission { get; set; }

        [Required]
        public DateTime date_limit { get; set; }

        [Required]
        public bool quarantee { get; set; }

        [Required]
        public DateTime date_admission { get; set; }

        [ForeignKey("customerDevice")]
        public int idCustDev { get; set; }

        public Customer_device customerDevice { get; set; }

        public List<Work_order> work_Order { get; set; }
    }
}
