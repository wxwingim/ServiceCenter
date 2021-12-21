using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Customer_device
    {
        [Key]
        public int idCustDev { get; set; }

        [Required]
        public string defect { get; set; }

        public string? equipment { get; set; }

        public string? mechanicalDamage { get; set; }

        [ForeignKey("customer")]
        public int idCustom { get; set; }

        public Customer customer { get; set; }

        [ForeignKey("deviceModel")]
        public int keyModel { get; set; }

        public Device_model deviceModel { get; set; }

        public List<Admission_for_repair> admissionForRepairs { get; set; }
    }
}
