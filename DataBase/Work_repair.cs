using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Work_repair
    {
        // Key
        [Key]
        public int numWork { get; set; }

        public DateTime? dateReady { get; set; }

        // Key
        [ForeignKey("workOrder")]
        public int numOrder { get; set; }

        public Work_order workOrder { get; set; }

        [ForeignKey("service")]
        public int keyService { get; set; }

        public Service service { get; set; }

        [ForeignKey("employee")]
        public int idWork { get; set; }

        public Employee employee { get; set; }

        public List<SalesInvoice> invoices { get; set; }
    }
}
