using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public DateTime datePurchase { get; set; }

        [ForeignKey("sparePart")]
        public int idSpare { get; set; }
        public SparePart sparePart { get; set; }
    }
}
