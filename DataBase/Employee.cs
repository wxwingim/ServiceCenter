using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Employee
    {
        [Key]
        public int idWork { get; set; }

        [Required]
        [MaxLength(20)]
        public string lastWork { get; set; }

        [Required]
        [MaxLength(20)]
        public string firstWork { get; set; }

        [MaxLength(20)]
        public string? middleWork { get; set; }

        [MaxLength(255)]
        public string mailWork { get; set; }

        [Required]
        [MaxLength(11)]
        public string phoneWork { get; set; }

        [Required]
        [MaxLength(50)]
        public string position { get; set; }

        public List<WorkRepair> workRepairs { get; set; }
    }
}
