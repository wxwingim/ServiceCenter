using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Service
    {
        [Key]
        public int keyService { get; set; }

        [Required]
        public string nameService { get; set; }

        [Required]
        public int priceService { get; set; }

        public List<Work_repair> workRepairs { get; set; }
    }
}
