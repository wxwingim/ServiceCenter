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
    public class SalesInvoice
    {
        public int numSales { get; set; }

        [Required]
        public DateTime dateSales { get; set; }

        [Required]
        public int amountSales { get; set; }

        [ForeignKey("workRepair")]
        public int numWork { get; set; }

        public Work_repair workRepair { get; set; }

        [ForeignKey("part")]
        public int idSpare { get; set; }

        public SparePart part { get; set; }

    }
}
