using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Consumption
    {
        [Key]
        public int IdConsumption { get; set; }

        [Required]
        public int amount { get; set; }

        [ForeignKey("sparePart")]
        public int idSpare { get; set; }
        public SparePart sparePart { get; set; }

        [ForeignKey("workOrder")]
        public int numOrder { get; set; }
        public WorkOrder workOrder { get; set; }
    }
}
