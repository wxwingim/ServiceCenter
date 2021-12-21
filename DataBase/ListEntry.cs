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
    public class ListEntry
    {
        //[Key]
        public int numRow { get; set; }

        [Required]
        public int amount { get; set; }

        [ForeignKey("sparePart")]
        public int idSpare { get; set; }

        public SparePart sparePart { get; set; }

        [ForeignKey("purchaseInvoice")]
        public int numPurchase { get; set; }

        public PurchaseInvoice purchaseInvoice { get; set; }
    }
}
