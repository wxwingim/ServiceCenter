using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class SparePart
    {
        [Key]
        public int idSpare { get; set; }

        [Required, StringLength(255)]
        public string nameSpare { get; set; }

        [Required]
        public int priceSpare { get; set; }

        [StringLength(4)]
        public string unitSpare { get; set; }

        public List<ListEntry> ListEntries { get; set; }

        public List<SalesInvoice> Invoices { get; set; }

    }
}
