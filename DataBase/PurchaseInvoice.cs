using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class PurchaseInvoice
    {
        [Key]
        public int numPurchase { get; set; }

        [Required]
        public DateTime datePurchase { get; set; }

        [ForeignKey("provider")]
        public int idProvider { get; set; }

        public Provider provider { get; set; }

        public List<SparePart> spareParts { get; set; }
    }
}
