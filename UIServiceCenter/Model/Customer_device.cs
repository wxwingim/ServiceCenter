using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Customer_device
    {
        [Key]
        public int idCustDev { get; set; }

        [Required]
        public string defect { get; set; }

        public string? equipment { get; set; }

        public string? mechanicalDamage { get; set; }

        public Customer idCustom { get; set; }

        public Device_model keyModel { get; set; }

        public List<Admission_for_repair> admissionForRepairs { get; set; }
    }
}
