using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Service
    {
        [Key]
        public int keyService { get; set; }

        [Required]
        public string nameService { get; set; }

        [Required]
        public int priceService { get; set; }

        public int guarantee { get; set; }

        public List<WorkRepair> workRepairs { get; set; }
    }
}
