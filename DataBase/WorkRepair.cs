using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class WorkRepair
    {
        // Key
        [Key]
        public int numWork { get; set; }

        public DateTime? dateReady { get; set; }

        [ForeignKey("workOrder")]
        public int numOrder { get; set; }
        public WorkOrder workOrder { get; set; }

        [ForeignKey("service")]
        public int keyService { get; set; }
        public Service service { get; set; }

        [ForeignKey("employee")]
        public int idWork { get; set; }
        public Employee employee { get; set; }

    }
}
