using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("typeSparePart")]
        public int IdTypeSP { get; set; }

        public TypeSparePart typeSparePart { get; set; }

        public List<Purchase> purchases { get; set; }
        public List<Consumption> consumptions { get; set; }

    }
}
