using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UIServiceCenter.Model
{
    public class Work_repair
    {
        [Key]
        public int numWork { get; set; }

        public DateTime? dateReady { get; set; }

        [Key]
        public Work_order numOrder { get; set; }

        public Service keyService { get; set; }

        public Employee idWork { get; set; }
    }
}
