using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class CustomerDevice
    {
        [Key]
        public int idCustDev { get; set; }

        [Required]
        public string defect { get; set; }

        public string? equipment { get; set; }

        public string? mechanicalDamage { get; set; }

        public string model { get; set; }

        [ForeignKey("customer")]
        public int idCustom { get; set; }

        public Customer customer { get; set; }

        [ForeignKey("type")]
        public int typeId { get; set; }

        public DeviceType type { get; set; }

        public List<AdmissionForRepair> admissionForRepairs { get; set; }
    }
}
