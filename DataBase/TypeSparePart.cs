using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class TypeSparePart
    {
        [Key]
        public int IdTypeSP { get; set; }

        [Required]
        public string name { get; set; }

        public List<SparePart> spareParts { get; set; }
    }
}
