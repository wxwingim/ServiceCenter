using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class StatusRepair
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string StatusName { get; set; }

        public List<WorkOrder> workOrders { get; set; }
    }
}
